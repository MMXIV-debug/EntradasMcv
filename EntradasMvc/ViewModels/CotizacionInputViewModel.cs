using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
namespace EntradasMvc.ViewModels
{
    public class CotizacionInputViewModel
    {
        [Required(ErrorMessage = "Ingrese el nombre del cliente.")]
        [StringLength(60, MinimumLength = 3,
            ErrorMessage = "El nombre debe tener entre 3 y 60 caracteres.")]
        [Display(Name = "Nombre del cliente")]
        public string Cliente { get; set; } = string.Empty;
        [Range(1, 10,
            ErrorMessage = "La cantidad debe estar entre 1 y 10")]
        [Display(Name = "Cantidad de entradas")]
        public int Cantidad { get; set; } = 1;
        [Required(ErrorMessage = "Debe seleccionar un tipo de entrada")]
        [Display(Name = "Tipo de Entrada")]
        public string TipoEntreda { get; set; } = string.Empty;

        public List<SelectListItem> TiposEntrada { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "General", Text = "General" },
            new SelectListItem { Value = "VIP", Text = "VIP" },
            new SelectListItem { Value = "Platea", Text = "Platea" }
        };
    }
}
