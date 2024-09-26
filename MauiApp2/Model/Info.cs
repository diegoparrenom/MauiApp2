using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace MauiApp2.Model;

public class Info
{
    public int page { get; set; }
    public int per_page {  get; set; }
    public int total { get; set; }
    public int total_pages {  get; set; }  
    public User[] data { get; set; }

}
