using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClientFunctionExecutor
{
    public delegate void ExecuteLogHandler(object message);

    public class FunctionExecutor
    {
        string formatedProgramText;
        public static ExecuteLogHandler OnExecute;

        private List<string> refferences = new List<string>();

        private List<string> usings = new List<string>();

        readonly string header = @"
            namespace CScript
            {
                public class Script
                {
                    public static void ScriptMethod(
            ";
        readonly string headerEnd = @")
                    { 
            ";
        readonly string footer = @"
                    }
                    static void Log(object message)
                    {
                        if(ClientFunctionExecutor.FunctionExecutor.OnExecute != null)
                            ClientFunctionExecutor.FunctionExecutor.OnExecute(message);
                    }
                }
            }";


        public FunctionExecutor(ExecuteLogHandler onExecute)
        {
            OnExecute += onExecute;
            refferences.AddRange(new string[]
                 {
                    "System.dll",
                    "System.Core.dll",
                    "System.Net.dll",
                    "System.Data.dll",
                    "System.Drawing.dll",
                    "System.Windows.Forms.dll",
                    Assembly.GetAssembly(typeof(FunctionExecutor)).Location,

                 });
            usings.AddRange(new string[]
             {
                    "System",
                    "System.IO",
                    "System.Net",
                    "System.Threading",
                    "System.Collections.Generic",
                    "System.Text",
                    "System.Text.RegularExpressions",
                    "System.ComponentModel",
                    "System.Data",
                    "System.Drawing",
                    "System.Diagnostics",
                    "System.Linq",
                    "System.Windows.Forms"
             });
        }

        public void Execute()
        {
            Execute(formatedProgramText);
        }

        public void Execute(string program)
        {
            var CSHarpProvider = CSharpCodeProvider.CreateProvider("CSharp");
            CompilerParameters compilerParams = new CompilerParameters()
            {
                GenerateExecutable = false,
                GenerateInMemory = true,
            };
            compilerParams.ReferencedAssemblies.AddRange(refferences.ToArray());
            var compilerResult = CSHarpProvider.CompileAssemblyFromSource(compilerParams, program);
            if (compilerResult.Errors.Count == 0)
            {
                try
                {
                    var method = compilerResult.CompiledAssembly.GetType("CScript.Script").GetMethod("ScriptMethod");
                    List<object> _params = new List<object>();
                    foreach (var par in method.GetParameters())
                    {
                        _params.Add(par.DefaultValue);
                    }
                    method.Invoke(null, _params.ToArray());
                }
                catch (Exception e)
                {
                    OnExecute(e.InnerException.Message + "rn" + e.InnerException.StackTrace);
                }
            }
            else
            {
                foreach (var oline in compilerResult.Output)
                    OnExecute(oline);
            }
        }

        public string FormatSources(string text, string parameters)
        {
            string usings = FormatUsings();
            formatedProgramText = string.Concat(usings, header, parameters, headerEnd, text, footer);
            return formatedProgramText;
        }

        private string FormatUsings()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string using_str in usings)
                sb.AppendFormat("using {0};{1}", using_str, Environment.NewLine);
            return sb.ToString();
        }
    }
}
