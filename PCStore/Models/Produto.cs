using System;

namespace PCStore.Models
{
    public class Produto {
        public int Id  { get; set; }
        public int typeId { get; set; }
        public required string nome  { get; set; }
        public required string marca  { get; set; }
        public required double price  { get; set; }
        public required string img { get; set; }
        public required string desc  { get; set; }
        public string ProcModelo  { get; set; }
        public string VideoModelo  { get; set; }
        public int tamRam  { get; set; }
        public string MaeModelo { get; set; }
        public int tamArm  { get; set; }
        public int velArm  { get; set; }
        public int potenciaFonte  { get; set; }
        public double monitorTamanho  { get; set; }
        public string MonitorRes  { get; set; }
        public bool monitorHDR { get; set; }
    }
}