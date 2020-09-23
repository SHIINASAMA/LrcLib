using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LrcLib.LrcData;
using LrcLib.LrcAdapter;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestWriteMethod()
        {
            LrcObject lrc = new LrcObject();
            lrc.LrcHeaders[(int)LrcHeader.Type.AR].Text = "AR";
            lrc.LrcHeaders[(int)LrcHeader.Type.AL].Text = "AL";
            lrc.LrcHeaders[(int)LrcHeader.Type.BY].Text = "BY";
            lrc.LrcHeaders[(int)LrcHeader.Type.TI].Text = "TI";
            lrc.LrcHeaders[(int)LrcHeader.Type.OFFSET].Text = "OFFSET";
            lrc.LrcLines.Add(new LrcLine(new TimeSpan(0, 0, 0, 0, 0), "This is a test."));
            LrcAdaper.WriteToFile(ref lrc, @"..\..\..\LrcLib\TestWrite.lrc");
        }

        [TestMethod]
        public void TestReadMethod()
        {
            LrcObject lrc = new LrcObject();
            LrcAdaper.ReadFromFile(ref lrc, @"..\..\..\LrcLib\TestRead.lrc");
            Console.WriteLine("AR:\t{0}",lrc.LrcHeaders[(int)LrcHeader.Type.AR].Text);
            Console.WriteLine("AL:\t{0}",lrc.LrcHeaders[(int)LrcHeader.Type.AL].Text);
            Console.WriteLine("BY:\t{0}",lrc.LrcHeaders[(int)LrcHeader.Type.BY].Text);
            Console.WriteLine("TI:\t{0}",lrc.LrcHeaders[(int)LrcHeader.Type.TI].Text);
            Console.WriteLine("OFFSET:\t{0}",lrc.LrcHeaders[(int)LrcHeader.Type.OFFSET].Text);

            Console.WriteLine("Time\tText");
            foreach(LrcLine line in lrc.LrcLines)
            {
                Console.WriteLine("{0}\t{1}",LrcLine.TimeToString(line.Time),line.Text);
            }
        }
    }
}
