public class DefaultController : ApiControllerBase{

    private async Task<void> AnyMethod(){
        await (CreateDeviceDataInserts("fcc5c09c-f7b7-4f45-adca-c22fa3fa9fc5"));
        
    }

    //Any methods and fields

    private async Task<bool> CreateDeviceDataInserts(string deviceID)
    {
        var retVal = false;
        try
        {
            var deviceDataList = (await new Table<DeviceData>(DB.Instance).Where(q => q.DeviceID == deviceID).ExecuteAsync()).ToList();
            using (StreamWriter outputFile = new StreamWriter("insertData.txt", true))
            {
                foreach (var deviceData in deviceDataList)
                {
                    var insertString = "INSERT INTO 'device_data'('device_id', 'update_time', 'alarm', 'alarm10', 'alarm11', 'alarm2', 'alarm3', 'alarm4', 'alarm5', 'alarm6', 'alarm7', 'alarm8', 'alarm9', 'capvarh', 'exwh', 'generator', 'imwh', 'indvarh', 'thdi1', 'thdi2', 'thdi3', 'thdv1', 'thdv2', 'thdv3', 'tva', 'vln1', 'vln2', 'vln3', 'vln4') VALUES('" + deviceData.DeviceID + "', '" + Convert.ToDateTime(deviceData.UpdateTime).ToString("yyyy-MM-dd HH:mm:ss") + "', " + Convert.ToInt32(value: deviceData.Alarm) + ", " + Convert.ToInt32(value: deviceData.Alarm10) + ", " + Convert.ToInt32(value: deviceData.Alarm11) + ", " + Convert.ToInt32(value: deviceData.Alarm2) + ", " + Convert.ToInt32(value: deviceData.Alarm3) + ", " + Convert.ToInt32(value: deviceData.Alarm4) + ", " + Convert.ToInt32(value: deviceData.Alarm5) + ", " + Convert.ToInt32(value: deviceData.Alarm6) + ", " + Convert.ToInt32(value: deviceData.Alarm7) + ", " + Convert.ToInt32(value: deviceData.Alarm8) + ", " + Convert.ToInt32(value: deviceData.Alarm9) + ", " + Convert.ToDouble(value: deviceData.CapVarh) + ", " + Convert.ToDouble(value: deviceData.ExWh) + ", " + Convert.ToInt32(value: deviceData.Generator) + ", " + Convert.ToDouble(value: deviceData.ImWh) + ", " + Convert.ToDouble(value: deviceData.IndVarh) + ", " + Convert.ToDouble(value: deviceData.THDI1) + ", " + Convert.ToDouble(value: deviceData.THDI2) + ", " + Convert.ToDouble(value: deviceData.THDI3) + ", " + Convert.ToDouble(value: deviceData.THDV1) + ", " + Convert.ToDouble(value: deviceData.THDV2) + ", " + Convert.ToDouble(value: deviceData.THDV3) + ", " + Convert.ToDouble(value: deviceData.TVA) + ", " + Convert.ToDouble(value: deviceData.VLN1) + ", " + Convert.ToDouble(value: deviceData.VLN2) + ", " + Convert.ToDouble(value: deviceData.VLN3) + ", " + Convert.ToDouble(value: deviceData.VLN4) + ")\nGO";
                    outputFile.WriteLine(insertString);
                }
            }
            retVal = true;
        }
        catch (Exception e)
        {
            LogIt.Error(e);
        }
        return retVal;
    }

}
/*
-Öncelikle Cassandra veritabanındaki veriler çekilip deviceDataList değişkenine atandı
-StreamWriter bloğu açıldı ve gerekli parametreler girildi (Dosya yolu, ekleyerek yazma=true)
NOT: Dosya doğrudan projenin içinde olduğu için yol yazmaya gerek kalmadan sadece dosyanın adı yazıldı.
-Bloğun içine, deviceDataList içinde dönecek bir foreach yazıldı
-Her bir eleman, insertString isimli değişkene atandıktan sonra tek tek dosyaya yazdırıldı.
NOT: insertString değişkeninin başlangıcı sabit olup, deviceDataList'ten gelen veriler bu sabit stringin arkasına eklenmektedir.

YAPILAN CONVERT İŞLEMLERİ
Convert.ToDateTime(deviceData.UpdateTime).ToString("yyyy-MM-dd HH:mm:ss")
Convert.ToInt32(value: deviceData.Alarm1)
Convert.ToDouble(value: deviceData.TVA)

!! insertString değişkeninde " ve ' işaretlerinin kullanımına oldukça dikkat edilmeli.
 */