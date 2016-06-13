using System;

namespace NewModel.Infrastructure
{
    public class UnitOfWork : IDisposable
    {
        private readonly DataContext _cxt = new DataContext();

        private GenericRepository<Application> _applications;
        private GenericRepository<Component> _components;
        private GenericRepository<Education> _edLevels;
        private GenericRepository<Foreign> _foreignDegrees;
        private GenericRepository<Permit> _permits;
        private GenericRepository<Setting> _settings;
        private GenericRepository<Position> _positions;
        private GenericRepository<FccPosition> _fccPositions;
        private GenericRepository<YesNoDontKnow> _yesNoDontKnows;
        private GenericRepository<Race> _races;

        public GenericRepository<Application> Applications => _applications ?? (_applications = new GenericRepository<Application>(_cxt));
        public GenericRepository<Component> Components => _components ?? (_components = new GenericRepository<Component>(_cxt));
        public GenericRepository<Education> EdLevels => _edLevels ?? (_edLevels = new GenericRepository<Education>(_cxt));
        public GenericRepository<Foreign> ForeignDegrees => _foreignDegrees ?? (_foreignDegrees = new GenericRepository<Foreign>(_cxt));
        public GenericRepository<Permit> Permits => _permits ?? (_permits = new GenericRepository<Permit>(_cxt));
        public GenericRepository<Setting> Settings => _settings ?? (_settings = new GenericRepository<Setting>(_cxt));
        public GenericRepository<Position> Positions => _positions ?? (_positions = new GenericRepository<Position>(_cxt));
        public GenericRepository<FccPosition> FccPositions => _fccPositions ?? (_fccPositions = new GenericRepository<FccPosition>(_cxt));
        public GenericRepository<YesNoDontKnow> YesNoDontKnows => _yesNoDontKnows ?? (_yesNoDontKnows = new GenericRepository<YesNoDontKnow>(_cxt));
        public GenericRepository<Race> Races => _races ?? (_races = new GenericRepository<Race>(_cxt));

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
