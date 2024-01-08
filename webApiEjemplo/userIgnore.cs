using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace webApiEjemplo
{
    public class userIgnore
    {


        
            [JsonIgnore]

            public int? idUser { get; set; }

            public string Users { get; set; }

            public string pass { get; set; }

            public string email { get; set; }

            public int? Administrator { get; set; }

            public int? Manager { get; set; }

            public int? idNegocio { get; set; }

            public int? validated { get; set; }


        }


    
}
