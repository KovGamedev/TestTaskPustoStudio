using System;

public class WatchesModel
{
    public DateTime Time { get; set; }

    public void AddOneSecond() => Time = Time.AddSeconds(1);
}
