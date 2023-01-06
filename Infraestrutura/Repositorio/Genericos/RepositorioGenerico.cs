using Dominio.Interfaces.Genericas;
using Infraestrutura.Configuracao;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace Infraestrutura.Repositorio.Genericos
{
    public class RepositorioGenerico<T> : IGenerico<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<ContextoBase> _OptionsBuilder;

        public RepositorioGenerico()
        {
            _OptionsBuilder = new DbContextOptions<ContextoBase>();
        }

        public async Task Adicionar(T Objeto)
        {
            using (var data = new ContextoBase(_OptionsBuilder))
            {

                await data.Set<T>().AddAsync(Objeto);
                await data.SaveChangesAsync();

            }
        }

        public async Task Atualizar(T Objeto)
        {
            using (var data = new DbContext(_OptionsBuilder))
            {

                data.Set<T>().Update(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task Deletar(T Objeto)
        {
            using (var data = new DbContext(_OptionsBuilder))
            {
                data.Set<T>().Remove(Objeto);
                await data.SaveChangesAsync();

            }
        }

        public async Task<T> ListarPorId(int id)
        {
            using (var data = new DbContext(_OptionsBuilder))
            {
              return await data.Set<T>().FindAsync(id);
            }
        }

        public async Task<IEnumerable<T>> ListarTudo()
        {
            using (var data = new DbContext(_OptionsBuilder))
            {
                return await data.Set<T>().ToListAsync();
            }
        }

        #region

        private bool _disposedValue;

        // Instantiate a SafeHandle instance.
        private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose() => Dispose(true);

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _safeHandle.Dispose();
                }

                _disposedValue = true;
            }
        }

        #endregion
    }
}