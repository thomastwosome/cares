using System;

namespace Model.Infrastructure
{
    public class UnitOfWork : IDisposable
    {
        private readonly DataContext _cxt = new DataContext();

        private GenericRepository<Application> _applications;
        private GenericRepository<Ethnicity> _ethnicities;
        private GenericRepository<Program> _programs;
        private GenericRepository<Degree> _degrees;
        private GenericRepository<CredentialType> _credentialTypes;

        public GenericRepository<Application> Applications => _applications ?? (_applications = new GenericRepository<Application>(_cxt));
        public GenericRepository<Ethnicity> Ethnicities => _ethnicities ?? (_ethnicities = new GenericRepository<Ethnicity>(_cxt));
        public GenericRepository<Program> Programs => _programs ?? (_programs = new GenericRepository<Program>(_cxt));
        public GenericRepository<Degree> Degrees => _degrees ?? (_degrees = new GenericRepository<Degree>(_cxt));
        public GenericRepository<CredentialType> CredentialTypes => _credentialTypes ?? (_credentialTypes = new GenericRepository<CredentialType>(_cxt));

        public void Save()
        {
            _cxt.SaveChanges();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _cxt.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}