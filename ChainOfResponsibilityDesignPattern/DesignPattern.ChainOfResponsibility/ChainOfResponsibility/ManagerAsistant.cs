using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
    public class ManagerAsistant : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context c = new Context();
            if (req.Amount <= 150000)
            {
                CustomerProcess cm = new CustomerProcess();
                cm.Amount = req.Amount.ToString();
                cm.Name = req.Name;
                cm.EmployeeName = "Şube Müdür Yardımcısı - Melike Öztürk ";
                cm.Description = "Para çekme işlemi onaylandı , talep edilen tutar müşteriye ödendi";
                c.CustomerProcesses.Add(cm);
                c.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcess cm = new CustomerProcess();
                cm.Amount = req.Amount.ToString();
                cm.Name = req.Name;
                cm.EmployeeName = "Şube Müdür Yardımcısı - Melike Öztürk";
                cm.Description = "Para çekme tutarı şube müdür yardımcısının günlük ödeme limitini aştığı için , işlem şube müdürüne yönlendirildi";
                c.CustomerProcesses.Add(cm);
                c.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
