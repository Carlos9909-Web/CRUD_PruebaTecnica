using CRUD_Prueba_Tecnica.Datos;
using CRUD_Prueba_Tecnica.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Prueba_Tecnica.Controllers
{
    public class ProductosController : Controller
    {
        ProductoDatos _ProductoDatos = new ProductoDatos();
        VentaDatos _VentaDatos = new VentaDatos();
        public IActionResult MostrarProductos()
        {
            var oListaProductos = _ProductoDatos.GetProductos();
            return View(oListaProductos);
        }
        public IActionResult GuardarProducto()
        {
            //Devuelve la vista de guardar
            return View();
        }
        [HttpPost]
        public IActionResult GuardarProducto(ProductoModel oProducto)
        {
            if (!ModelState.IsValid)
                return View();

            //Recibe el objeto para guardar en base de datos
            var res = _ProductoDatos.SaveProducto(oProducto);
            if (res)
                return RedirectToAction("MostrarProductos");
            else
                return View();
        }
        public IActionResult EditarProducto(int IdProducto)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var ocontacto = _ProductoDatos.GetProducto(IdProducto);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult EditarProducto(ProductoModel oProducto)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _ProductoDatos.EditarProducto(oProducto);

            if (respuesta)
                return RedirectToAction("MostrarProductos");
            else
                return View();
        }
        public IActionResult EliminarProducto(int IdProducto)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var ocontacto = _ProductoDatos.GetProducto(IdProducto);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult EliminarProducto(ProductoModel oProducto)
        {
            var respuesta = _ProductoDatos.EliminarProducto(oProducto.IdProducto);

            if (respuesta)
                return RedirectToAction("MostrarProductos");
            else
                return View();
        }
        public IActionResult VentaProducto(int IdProducto)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var oproducto = _ProductoDatos.GetProducto(IdProducto);

            if (oproducto.CantidadDisponible > 0)
            {
                bool respuesta = _ProductoDatos.VentaProducto(oproducto);
            }

            return RedirectToAction("MostrarProductos");
        }
        public IActionResult MostrarGanancias()
        {
            var oListaProductos = _VentaDatos.GetGanancias();
            return View(oListaProductos);
        }
    }
}
