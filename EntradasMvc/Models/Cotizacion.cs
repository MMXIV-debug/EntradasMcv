using System.ComponentModel.DataAnnotations;

namespace EntradasMvc.Models
{
    public class Cotizacion
    {
        public string Cliente { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal PrecioUnitario => TipoEntreda switch
        {
            "VIP" => 150m,
            "Platea" => 100m,
            "General" => 50m,
            _ => 50m
        };
        public decimal Subtotal => Cantidad * PrecioUnitario;
        public decimal Descuento => Cantidad >= 5 ? Subtotal * 0.10m : 0m;
        public decimal Total => Subtotal - Descuento;
        public string TipoEntreda { get; set; } = string.Empty;
    }
}
