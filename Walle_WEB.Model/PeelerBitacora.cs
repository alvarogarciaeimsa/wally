using System.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Walle_WEB.Model
{
    public class PeelerBitacora
    {
        public int IdPeeler { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El numero de lote es requerido")]
        public string NoDeLote { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El numero de bloque es requerido")]
        public int NoDeBloque { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El tipo de espuma es requerido")]
        public string TipoDeEspuma { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Pedido is required")]
        public int IdPedido { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Operador is required")]
        public int IdOperador { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Maquina is required")]
        public int IdMaquina { get; set; }
        public int IdTurno { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Fecha is required")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaPeeler { get; set; }
        public bool Dañado { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Detalles Name is required")]
        public string DetallesId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Peso Rollo is required")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        [RegularExpression(@"[0-9]*\.?[0-9]*", ErrorMessage = "La cantidad debe contener sólo números y dos decimales")]
        public decimal PesoRollo { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Rollo is required")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        [RegularExpression(@"[0-9]*\.?[0-9]*", ErrorMessage = "La cantidad debe contener sólo números y dos decimales")]
        public int NoRollo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Alma is required")]
        public int Alma { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Espesor is required")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        [RegularExpression(@"[0-9]*\.?[0-9]*", ErrorMessage = "La cantidad debe contener sólo números y dos decimales")]

        public decimal Espesor { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Largo is required")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        [RegularExpression(@"[0-9]*\.?[0-9]*", ErrorMessage = "La cantidad debe contener sólo números y dos decimales")]

        public decimal Largo { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Recuperable is required")]
        public decimal PesoRecuperable { get; set; }
        public decimal PesoDesperdicio { get; set; }
        public TimeSpan HoraInicial { get; set; }
        public TimeSpan HoraFinal { get; set; }
        public DateTime? Created { get; set; }
        public int? UserCreated { get; set; }
        public DateTime? Updated { get; set; }
        public int? UserUpdated { get; set; }


        public event Action OnSelectedPeelerChanged;
        public void SelectedPeelerChanged(PeelerBitacora peeler)
        {
            IdPeeler = peeler.IdPeeler;
            FechaPeeler = peeler.FechaPeeler;
            NoRollo = peeler.NoRollo;
            NoDeBloque = peeler.NoDeBloque;
            NoDeLote = peeler.NoDeLote;

            NotifySelectedPeelerChanged();
        }

        private void NotifySelectedPeelerChanged()
        {
            OnSelectedPeelerChanged.Invoke();
        }
    }
}
