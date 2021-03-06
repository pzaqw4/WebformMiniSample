using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TryReadWebAPI
{
    class WeatherDataReader
    {
        public static void ReadData()
        {
            string url = "https://opendata.cwb.gov.tw/fileapi/v1/opendataapi/F-B0053-037?Authorization=CWB-4ED7C2EE-D607-42ED-BC57-D9911F471334&downloadType=WEB&format=JSON";

            WebClient client = new WebClient();
            byte[] sourceByte = client.DownloadData(url);
            //DownloadData先將編碼下載,在儲存到陣列變數中
            string jsonText = Encoding.UTF8.GetString(sourceByte);
            //在將變數轉碼成符合UTF8的文字
            
            
            
            //serialize序列化  //Deserialize為反序列化
            Rootobject obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Rootobject>(jsonText);
            //將(jsonText)這個Json文字反序列化後轉換為<Temp>這個型別,然後塞到obj這個變數內

            var locationList = obj.cwbopendata.dataset.locations.location;

            foreach(var item in locationList)
            {
                if(string.Compare("太魯閣國家公園太魯閣遊客中心",item.locationName,true)==0)
                {
                    foreach(var weatherItem in item.weatherElement)
                    {
                        if(weatherItem.elementName =="T")
                        {
                            var eleVal = weatherItem.time[0].elementValue;
                            var tJsonText = Newtonsoft.Json.JsonConvert.SerializeObject(eleVal);//序列化
                            MeasureObject measure = Newtonsoft.Json.JsonConvert.DeserializeObject<MeasureObject>(tJsonText);
                            Console.WriteLine("太魯閣國家公園太魯閣遊客中心 - 目前溫度:"+measure.value);
                        }
                        if (weatherItem.elementName == "PoP24h")
                        {
                            var eleVal = weatherItem.time[0].elementValue;
                            var tJsonText = Newtonsoft.Json.JsonConvert.SerializeObject(eleVal);
                            MeasureObject measure = Newtonsoft.Json.JsonConvert.DeserializeObject<MeasureObject>(tJsonText);
                            Console.WriteLine("太魯閣國家公園太魯閣遊客中心 - 降雨機率:" + measure.value);
                        }
                    }
                }
            }

            //Console.WriteLine(jsonText);

        }
    }

     public class MeasureObject
    {
        public string value { get; set; }
        public string measures { get; set; }

    }
    public class Rootobject
    {
        public Cwbopendata cwbopendata { get; set; }
    }

    public class Cwbopendata
    {
        public string xmlns { get; set; }
        public string identifier { get; set; }
        public string sender { get; set; }
        public DateTime sent { get; set; }
        public string status { get; set; }
        public string scope { get; set; }
        public string msgType { get; set; }
        public string dataid { get; set; }
        public string source { get; set; }
        public Dataset dataset { get; set; }
    }

    public class Dataset
    {
        public Datasetinfo datasetInfo { get; set; }
        public Locations locations { get; set; }
    }

    public class Datasetinfo
    {
        public string datasetDescription { get; set; }
        public string datasetLanguage { get; set; }
        public DateTime issueTime { get; set; }
        public Validtime validTime { get; set; }
        public DateTime update { get; set; }
    }

    public class Validtime
    {
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
    }

    public class Locations
    {
        public string[] locationsName { get; set; }
        public Location[] location { get; set; }
    }

    public class Location
    {
        public string locationName { get; set; }
        public string geocode { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public Parameterset parameterSet { get; set; }
        public Weatherelement[] weatherElement { get; set; }
    }

    public class Parameterset
    {
        public Parameter parameter { get; set; }
    }

    public class Parameter
    {
        public string parameterName { get; set; }
        public string parameterValue { get; set; }
    }

    public class Weatherelement
    {
        public string elementName { get; set; }
        public string description { get; set; }
        public Time[] time { get; set; }
    }

    public class Time
    {
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public object elementValue { get; set; }
    }

}
