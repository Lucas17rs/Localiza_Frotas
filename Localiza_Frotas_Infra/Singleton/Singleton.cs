using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localiza_Frotas_Infra.Singleton
{
    public sealed class Singleton
    {
        public Guid Id { get; } = Guid.NewGuid();

        private static Singleton instance = null;

        private Singleton() { }

        public static Singleton Instace
        {
            get
            {
                if(instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }

    }
}
