using Core.Entities;
using Core.Entities.Concrete;
using Newtonsoft.Json;

namespace Entities.Concrete;

public class Address : BaseEntity
{
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string PostalCode { get; set; }
    public string FullAddress { get; set; }


    //relation
    [JsonIgnore] public User User { get; set; }
    public int UserId { get; set; }
}