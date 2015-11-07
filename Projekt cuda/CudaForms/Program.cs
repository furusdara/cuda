using ManagedCuda;
using ManagedCuda.BasicTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CudaForms
{
    static class Program
    {
        static ManagedCuda.CudaKernel addWithCuda;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            InitKernels();
            var result = cudaAdd(3, 10);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }

        public static void InitKernels()
        {
            CudaContext cntxt = new CudaContext();

            CUmodule cumodule = cntxt.LoadModule(@"C:\Users\Michał\Documents\Visual Studio 2013\Projects\cuda\Projekt cuda\Projekt cuda\Debug\kernel.ptx");
            //CUmodule cumodule = cntxt.LoadModule(@"D:\Grafika\cuda\Projekt cuda\Projekt cuda\Debug\kernel.ptx");
            addWithCuda = new CudaKernel("_Z6kerneliiPi", cumodule, cntxt);
        }

        public static Func<int, int, int> cudaAdd = (a, b) =>
        {
            // init output parameters
            CudaDeviceVariable<int> result_dev = 0;
            int result_host = 0;
            // run CUDA method
            addWithCuda.Run(a, b, result_dev.DevicePointer);
            // copy return to host
            result_dev.CopyToHost(ref result_host);
            return result_host;
        };


    }
}
