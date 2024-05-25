using MextFullStack.Domain.Common;

namespace MextFullStack.Domain;

public class Customer:EntityBase<string>
{
    
    public string  Name { get; set; }

    public string Address { get; set; }

    public String Email { get; set; }

    public String Phone { get; set; }

   

    public Customer()
    {
        CreatedOn = DateTime.Now;

        Id = Guid.NewGuid().ToString();
    }


}
