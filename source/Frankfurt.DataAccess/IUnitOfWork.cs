using System;
using System.Threading;
using System.Threading.Tasks;

namespace Frankfurt.DataAccess
{
    public interface IUnitOfWork
    {
        void SaveChanges();

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        public UnitOfWork(DatabaseContext databaseContext)
        {
            _context = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}