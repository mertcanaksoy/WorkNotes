using System;
using System.Collections.Generic;
using Newtonsoft.Json;


public class Account
{
    public string Email { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedDate { get; set; }
    public IList<string> Roles { get; set; }
}            


public class Program
{
	public static void Main()
	{
        //SerializeObject
		Account account = new Account{
            Email ="mert@mert.com",
            Active=true,
            CreatedDate = new DateTime(2019, 7, 30, 0, 0, 0, DateTimeKind.Utc),
            Roles = new List<string>{
                "User",
                "Admin"
            }
        };

        string json = JsonConvert.SerializeObject(account, Formatting.Indented);
		Console.WriteLine(json);

        //DeserializeObject
        string jsonn = @"{
  		'Email': 'mert@mert.com',
  		'Active': true,
  		'CreatedDate': '2019-07-30T00:00:00Z',
  		'Roles': [
    		'User',
    		'Admin'
  		]
		}";

		Account accound = JsonConvert.DeserializeObject<Account>(jsonn);
		Console.WriteLine(accound.Email);

	}
}
