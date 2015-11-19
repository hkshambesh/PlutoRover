using System;
using System.Reflection;
using Ninject;

namespace PlutoRover.IoC
{
    public static class DependencyResolver
    {
        private static readonly Lazy<IKernel> Instance = new Lazy<IKernel>(() =>
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            return kernel;
        });

        public static IKernel Kernel
        {
            get { return Instance.Value; }
        }
    }
}