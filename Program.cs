using Dsw2025Ej8.Domain;
using static Dsw2025Ej8.Domain.Exceptions.Excepciones;

namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cuentas = new List<CuentaBancaria>();

            var ca1 = new CuentaDeAhorro("CA-001", 1000, new[] { "Ana" }) { _tasaDeInteres = 0.02m };
            var ca2 = new CuentaDeAhorro("CA-002", 500, new[] { "Luis" }) { _tasaDeInteres = 0.015m };

            var cc1 = new CuentaCorriente("CC-001", 1500, new[] { "María" }) { _limiteDeDescubierto = 300, _comision = 0.1m };
            var cc2 = new CuentaCorriente("CC-002", 200, new[] { "Pedro" }) { _limiteDeDescubierto = 100, _comision = 0.05m };

            cuentas.Add(ca1);
            cuentas.Add(ca2);
            cuentas.Add(cc1);
            cuentas.Add(cc2);

            foreach (var cuenta in cuentas)
            {
                try
                {
                    cuenta.Depositar(200);
                    cuenta.Retirar(300);
                    cuenta.Retirar(2000);
                }
                catch (MontoNoValidoException ex)
                {
                    Console.WriteLine($"[ERROR] Cuenta {cuenta._numero}: {ex.Message}");
                }
                catch (CuentaNoActivaException ex)
                {
                    Console.WriteLine($"[ERROR] Cuenta {cuenta._numero}: {ex.Message}");
                }
                catch (SaldoInsuficienteException ex)
                {
                    Console.WriteLine($"[ERROR] Cuenta {cuenta._numero}: {ex.Message}");
                }
            }

            // Punto 11: Mostrar resumen con clase anónima
            Console.WriteLine("\nResumen de cuentas:");
            var resumenes = cuentas.Select(c => new
            {
                numero = c._numero,
                tipo = c.GetType().Name,
                saldo = c._saldo,
                titular = string.Join("", c._titulares)
            });

            foreach (var r in resumenes)
            {
                Console.WriteLine($"Cuenta: {r.numero} | Titular: {r.titular} | Tipo: {r.tipo} | Saldo: ${r.saldo:F2}");
            }
        }
    }
}
