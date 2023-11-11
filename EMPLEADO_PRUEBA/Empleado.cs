using System;

namespace EMPLEADO_PRUEBA
{
    abstract class Empleado
    {
        private string _Cedula;
        private string _Nombre;
        private bool _Activo;

        // Getters y setters

        public bool Activo
        {
            get { return _Activo; }
            set { _Activo = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string Cedula
        {
            get { return _Cedula; }
            set { _Cedula = value; }
        }

        // Constructores parametros

        public Empleado(string cedula, string nombre, bool activo)
        {
            this._Cedula = cedula;
            this._Nombre = nombre;
            this._Activo = activo;
        }

        public abstract double CalcularSalario();

        public override string ToString()
        {
            return "Cédula: " + Cedula + "\n" +
                   "Nombre: " + Nombre + "\n" +
                   "Activo: " + Activo;
        }
    }

    class Asalariado : Empleado
    {
        public double Salario { get; set; }

        public Asalariado(string cedula, string nombre, bool activo, double salario) : base(cedula, nombre, activo)
        {
            Salario = salario;
        }

        public override double CalcularSalario()
        {
            return Salario;
        }

        public override string ToString()
        {
            return base.ToString() + "\n" +
                   "Salario: " + Salario;
        }
    }

    class PorHora : Empleado
    {
        public double PrecioHora { get; set; }
        public int Horas { get; set; }

        public PorHora(string cedula, string nombre, bool activo, double precioHora, int horas) : base(cedula, nombre, activo)
        {
            PrecioHora = precioHora;
            Horas = horas;
        }

        public override double CalcularSalario()
        {
            return PrecioHora * Horas;
        }

        public override string ToString()
        {
            return base.ToString() + "\n" +
                   "Precio por hora: " + PrecioHora + "\n" +
                   "Horas trabajadas: " + Horas;
        }
    }

    class Comision : Empleado
    {
        public double Ventas { get; set; }
        public double PorcentajeComision { get; set; }

        public Comision(string cedula, string nombre, bool activo, double ventas, double porcentajeComision) : base(cedula, nombre, activo)
        {
            Ventas = ventas;
            PorcentajeComision = porcentajeComision;
        }

        public override double CalcularSalario()
        {
            return Ventas * (PorcentajeComision / 100);
        }

        public override string ToString()
        {
            return base.ToString() + "\n" +
                   "Ventas: " + Ventas + "\n" +
                   "Porcentaje de comisión: " + PorcentajeComision;
        }

        
    }
   
            
}
