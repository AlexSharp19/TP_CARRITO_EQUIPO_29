using System.ComponentModel;

namespace Domain.Entities
{
    public class MarcaEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
