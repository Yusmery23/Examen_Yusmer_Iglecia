namespace Taller_Mecanica.Models
{
    public class Mecanico
    {

        //Agrego las propiedades
        public int idMecanico { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Domicilio { get; set; }
        public string Titulo { get; set; }
        public string Especialidad { get; set; }
        public int SueldoBase { get; set; }
        public int GratTitulo { get; set; }
        public int SueldoTotal { get; set; }

    }
}
