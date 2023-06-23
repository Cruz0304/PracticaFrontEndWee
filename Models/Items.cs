using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Timers;

namespace PracticaFrontEnd.Models
{
    public class Items
    {
        public int id { get; set; }
        [Required(ErrorMessage = "El valor es requerido")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Escriba correctamente el nombre de la empresa")]
        [DataType(DataType.Text)]
        public string? NombreCompania { get; set; }
        [Required(ErrorMessage = "El valor es requerido")]
        [MinLength(8,ErrorMessage = "El campo debe contener 8 numeros")]
        [MaxLength(8,ErrorMessage = "El campo no debe contener mas de 8 numeros")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]        
        public string? Cedula { get; set; }
        [Required(ErrorMessage = "El valor es requerido")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Escriba correctamente el nombre")]
        [DataType(DataType.Text)]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El valor es requerido")]
        public string? Titulo { get; set; }
        [Required(ErrorMessage = "El valor es requerido")]
        [EmailAddress(ErrorMessage ="El formato del correo no es el correcto")]
        public string? Correo { get; set; }
        
        [Required(ErrorMessage = "El valor es requerido")]
        [RegularExpression("(^[0-9]+$)",ErrorMessage ="Solo se permiten numeros")]
        public string? telefono { get; set; }
    }
    public class Datos
    {
        public IList<Items>? Items { get; set; }

    }
}
