using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCStore.Config
{
    public class GlobalSettings
    {
            public static string DBPath { get; set; } = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=Admin#123"; //Caminho do Banco de dados
            public static string URL { get; set; } = "http://localhost:5066/"; //Caminho da URL do Site
    }
}