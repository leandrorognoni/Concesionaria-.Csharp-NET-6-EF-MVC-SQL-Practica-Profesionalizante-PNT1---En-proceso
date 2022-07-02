﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Concesionaria.Models;

namespace Concesionaria.Controllers
{
    public class VendedorController : Controller
    {
        private readonly ConcesionariaContext _context;

        public VendedorController(ConcesionariaContext context)
        {
            _context = context;
        }

        // GET: Vendedor
        public async Task<IActionResult> Index()
        {
              return _context.vendedores != null ? 
                          View(await _context.vendedores.ToListAsync()) :
                          Problem("Entity set 'ConcesionariaContext.vendedores'  is null.");
        }

        // GET: Vendedor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.vendedores == null)
            {
                return NotFound();
            }

            var vendedor = await _context.vendedores
                .FirstOrDefaultAsync(m => m.IdVendedor == id);
            if (vendedor == null)
            {
                return NotFound();
            }

            return View(vendedor);
        }

        //GET: Vendedor/Login
        public IActionResult Login()
        {

            return View();
        }
        //POST: Vendedor/Login
        [HttpPost] 
        public IActionResult Login(int? id)
        {
         

            return View();
        }

        // GET: Vendedor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vendedor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVendedor,Nombre,Apellido,Contraseña,Dni")] Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vendedor);
        }

        // GET: Vendedor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.vendedores == null)
            {
                return NotFound();
            }

            var vendedor = await _context.vendedores.FindAsync(id);
            if (vendedor == null)
            {
                return NotFound();
            }
            return View(vendedor);
        }

        // POST: Vendedor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVendedor,Nombre,Apellido,Contraseña,Dni")] Vendedor vendedor)
        {
            if (id != vendedor.IdVendedor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendedorExists(vendedor.IdVendedor))
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
            return View(vendedor);
        }

        // GET: Vendedor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.vendedores == null)
            {
                return NotFound();
            }

            var vendedor = await _context.vendedores
                .FirstOrDefaultAsync(m => m.IdVendedor == id);
            if (vendedor == null)
            {
                return NotFound();
            }

            return View(vendedor);
        }

        // POST: Vendedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.vendedores == null)
            {
                return Problem("Entity set 'ConcesionariaContext.vendedores'  is null.");
            }
            var vendedor = await _context.vendedores.FindAsync(id);
            if (vendedor != null)
            {
                _context.vendedores.Remove(vendedor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendedorExists(int id)
        {
          return (_context.vendedores?.Any(e => e.IdVendedor == id)).GetValueOrDefault();
        }
    }
}