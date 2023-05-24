using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
    public class AreaDirector : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context c = new Context();
            if (req.Amount <= 400000)
            {
                CustomerProcess cm = new CustomerProcess();
                cm.Amount = req.Amount.ToString();
                cm.Name = req.Name;
                cm.EmployeeName = "Bölge Müdürü - Levent Yılmaz";
                cm.Description = "Para çekme işlemi onaylandı , talep edilen tutar müşteriye ödendi";
                c.CustomerProcesses.Add(cm);
                c.SaveChanges();
            }
            else
            {
                CustomerProcess cm = new CustomerProcess();
                cm.Amount = req.Amount.ToString();
                cm.Name = req.Name;
                cm.EmployeeName = "Bölge Müdürü - Levent Yılmaz";
                cm.Description = "Para çekme tutarı bölge müdürünün günlük ödeme limitinin üzerinde olduğu için , işlem gerçekleştirilemedi.Müşterinin günlük çekebileceği tutar maksimum 400.009 Tl olup birden fazla gün şubeye gelmesi gerekli..";
                c.CustomerProcesses.Add(cm);
                c.SaveChanges();

            }
        }
    }
}