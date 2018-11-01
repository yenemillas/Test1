
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Telelingua.API.Business;

namespace Telelingua.Tests
{
    public static class IOC
    {

        private static Dictionary<Type, Func<object>> dico = new Dictionary<Type, Func<object>>
        {
                { typeof(IReadFiles), () => new FileManagement()}
        };

        public static TInterface Get<TInterface>() where TInterface : class
        {
            if (!dico.ContainsKey(typeof(TInterface)))
            {
                throw new ArgumentException("type inconnu");
            }

            return dico[typeof(TInterface)]() as TInterface;
        }
    }
}