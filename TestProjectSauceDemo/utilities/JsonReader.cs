using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace TestProjectSauceDemo.utilities
{
    public class JsonReader
    {

        public JsonReader()
        {
        }
        public string extractData(String tokenName)
        {
           String myJsonString =File.ReadAllText("utilities/testData.json");
           var jsonObject=JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }
    }
}
