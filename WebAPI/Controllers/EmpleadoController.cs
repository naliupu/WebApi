using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models.DAL;
using WebAPI.Models.Entities;

namespace WebAPI.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly DbContextPrueba _context;

        public EmpleadoController(DbContextPrueba context)
        {
            _context = context;
        }

        // GET: Empleado
        public async Task<IActionResult> Index()
        {
            return View(await _context.Empleados.ToListAsync());
        }

        /*
        // GET: Empleado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empledos
                .FirstOrDefaultAsync(m => m.IdEmpleado == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }
        */

        // GET: Empleado/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        public IActionResult CrearEditar(int id = 0)
        {
            if (id == 0)
            {
                return View(new Empleado());
            }
            else
            {
                return View(_context.Empleados.Find(id));
            }

        }

        // POST: Empleado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearEditar([Bind("IdEmpleado,Nombre,Documento,Cargo,Telefono")] Empleado empleado)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Add(empleado);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(empleado);
            if (ModelState.IsValid)
            {
                if (empleado.IdEmpleado == 0)
                    _context.Add(empleado);
                else
                    _context.Update(empleado);

                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        /*

        // GET: Empleado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empledos.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

        // POST: Empleado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEmpleado,Nombre,Documento,Cargo,Telefono")] Empleado empleado)
        {
            if (id != empleado.IdEmpleado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.IdEmpleado))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }
        */

        // GET: Empleado/Delete/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var empleado = await _context.Empledos
            //    .FirstOrDefaultAsync(m => m.IdEmpleado == id);
            //if (empleado == null)
            //{
            //    return NotFound();
            //}

            //return View(empleado);

            var empleado = await _context.Empleados.FindAsync(id);
            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        /*
        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _context.Empledos.FindAsync(id);
            _context.Empledos.Remove(empleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        */

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.IdEmpleado == id);
        }
    }
}
