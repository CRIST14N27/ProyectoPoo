using Proyecto_Final.Context;
using Proyecto_Final.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final.services
{
    public class UsuarioServices
    {
        public void addUser(Usuario request)//request es una solicitud
        {
            try
            {
                if (request == null)
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        Usuario res = new Usuario();
                        res.Nombre = request.Nombre;
                        res.UserName = request.UserName;
                        res.Password = request.Password;
                        //res.FkRol = request.FkRol;
                        _context.Usuarios.Add(res);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error inesperado"+ex.Message);
            }
        }
        public List<Usuario> Read()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Usuario> usuarios = new List<Usuario>();
                    usuarios = _context.Usuarios.ToList();
                    return usuarios;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un error inesperado" + ex.Message);
            }
           
        }
    }
}
