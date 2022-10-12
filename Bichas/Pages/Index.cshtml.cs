using Bichas.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bichas.Pages
{
    public class IndexModel : PageModel
    {
        public IndexModel()
        {
            BichasDb = new BichasDbContext();
            ReservaList = new List<Reserva>();
        }
        public List<Reserva> ReservaList { get; set; }
        public BichasDbContext BichasDb { get; set; }
        public PageResult OnGet()
        {
            //Coloca a instância Reservas em forma de lista no ReservaList
            ReservaList = BichasDb.Reservas.Where(x => x.ENTROU == false).ToList();
            ViewData["ListItemsMesas"] = new SelectList(ListItemsMesas(), "Value", "Text");
            return Page();
        }
        public List<SelectListItem> ListItemsMesas()
        {
            var mesas = BichasDb.Mesas.ToList();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in mesas)
            {
                items.Add(new SelectListItem { Value = item.ID_MESA.ToString(), Text = item.DS_MESA });
            }
            return items;
        }
        public ActionResult OnPost(Reserva reserva)
        {
            var DS_MESA = getMesa(reserva.QTD_PESSOAS);
            var mesaReserva = BichasDb.Mesas.FirstOrDefault(x => x.DS_MESA == DS_MESA);
            if (mesaReserva == null)
            {
                var newMesa = new Mesa();
                newMesa.DS_MESA = DS_MESA;
                BichasDb.Add(newMesa);
                BichasDb.SaveChanges();
                mesaReserva = newMesa;
            }
            reserva.ID_MESA = mesaReserva.ID_MESA;

            BichasDb.Reservas.Add(reserva);
            BichasDb.SaveChanges();

            return RedirectToPage("Index");
        }

        public string getMesa(int QTD_PESSOAS)
        {
            switch (QTD_PESSOAS)
            {
                case 1: return "Um";
                case 2: return "Dois";
                case 3: return "Tres";
                case 4: return "Quatro";
                case 5: return "Cinco";
                case 6: return "Seis";
                case 7: return "Sete";
                case 8: return "Oito";
                case 9: return "Nove";
                default: return "Dez+";
            }
        }

        public ActionResult OnPostEntrar(int ID_RESERVA)
        {
            var reserva = BichasDb.Reservas.Find(ID_RESERVA);
            if (reserva != null)
            {
                reserva.ENTROU = true;
                BichasDb.SaveChanges();
            }
            return RedirectToPage("Index");
        }

        
    }
}