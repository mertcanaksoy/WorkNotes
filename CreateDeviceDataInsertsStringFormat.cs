
    private async Task<bool> CreateDeviceDataInserts(string deviceID)
        {
            var retVal = false;
            var vln4 = string.Empty;
            var vln3 = string.Empty;
            var vln2 = string.Empty;
            var vln1 = string.Empty;
            var tva = string.Empty;
            var thdv3 = string.Empty;
            var thdv2 = string.Empty;
            var thdv1 = string.Empty;
            var thdi3 = string.Empty;
            var thdi2 = string.Empty;
            var thdi1 = string.Empty;
            var indvarh = string.Empty;
            var imwh = string.Empty;
            var capvarh = string.Empty;
            var exwh = string.Empty;


            try
            {
                var deviceDataList = (await new Table<DeviceData>(DB.Instance).Where(q => q.DeviceID == deviceID).ExecuteAsync()).ToList();

                using (StreamWriter outputFile = new StreamWriter("insertData.txt", true))
                {
                   
                    foreach (var deviceData in deviceDataList)
                    {
                        if (deviceData.VLN4 == null)
                        {
                            vln4 = "NULL";
                        }
                        else
                        {
                            vln4 = deviceData.VLN4.ToString();
                            vln4 = vln4.Replace(",", ".");
                        }

                        if (deviceData.VLN3 == null)
                        {
                            vln3 = "NULL";
                        }
                        else
                        {
                            vln3 = deviceData.VLN3.ToString();
                            vln3 = vln3.Replace(",", ".");
                        }

                        if (deviceData.VLN2 == null)
                        {
                            vln2 = "NULL";
                        }
                        else
                        {
                            vln2 = deviceData.VLN2.ToString();
                            vln2 = vln2.Replace(",", ".");
                        }

                        if (deviceData.VLN1 == null)
                        {
                            vln1 = "NULL";
                        }
                        else
                        {
                            vln1 = deviceData.VLN1.ToString();
                            vln1 = vln1.Replace(",", ".");
                        }

                        if (deviceData.TVA == null)
                        {
                            tva = "NULL";
                        }
                        else
                        {
                            tva = deviceData.TVA.ToString();
                            tva = tva.Replace(",", ".");
                        }

                        if (deviceData.THDV3 == null)
                        {
                            thdv3 = "NULL";
                        }
                        else
                        {
                            thdv3 = deviceData.THDV3.ToString();
                            thdv3 = thdv3.Replace(",", ".");
                        }

                        if (deviceData.THDV2 == null)
                        {
                            thdv2 = "NULL";
                        }
                        else
                        {
                            thdv2 = deviceData.THDV2.ToString();
                            thdv2 = thdv2.Replace(",", ".");
                        }

                        if (deviceData.THDV1 == null)
                        {
                            thdv1 = "NULL";
                        }
                        else
                        {
                            thdv1 = deviceData.THDV1.ToString();
                            thdv1 = thdv1.Replace(",", ".");
                        }

                        if (deviceData.THDI3 == null)
                        {
                            thdi3 = "NULL";
                        }
                        else
                        {
                            thdi3 = deviceData.THDI3.ToString();
                            thdi3 = thdi3.Replace(",", ".");
                        }

                        if (deviceData.THDI2 == null)
                        {
                            thdi2 = "NULL";
                        }
                        else
                        {
                            thdi2 = deviceData.THDI2.ToString();
                            thdi2 = thdi2.Replace(",", ".");
                        }

                        if (deviceData.THDI1 == null)
                        {
                            thdi1 = "NULL";
                        }
                        else
                        {
                            thdi1 = deviceData.THDI1.ToString();
                            thdi1 = thdi1.Replace(",", ".");
                        }

                        if (deviceData.IndVarh == null)
                        {
                            indvarh = "NULL";
                        }
                        else
                        {
                            indvarh = deviceData.IndVarh.ToString();
                            indvarh = indvarh.Replace(",", ".");
                        }
                        if (deviceData.ImWh == null)
                        {
                            imwh = "NULL";
                        }
                        else
                        {
                            imwh = deviceData.ImWh.ToString();
                            imwh = imwh.Replace(",", ".");
                        }

                        if (deviceData.CapVarh == null)
                        {
                            capvarh = "NULL";
                        }
                        else
                        {
                            capvarh = deviceData.CapVarh.ToString();
                            capvarh = capvarh.Replace(",", ".");
                        }
                        if (deviceData.ExWh == null)
                        {
                            exwh = "NULL";
                        }
                        else
                        {
                            exwh = deviceData.ExWh.ToString();
                            exwh = exwh.Replace(",", ".");
                        }


                        var insertString = "INSERT INTO device_data(device_id, update_time, alarm, alarm10, alarm11, alarm2, alarm3, alarm4, alarm5, alarm6, alarm7, alarm8, alarm9, capvarh, exwh, generator, imwh, indvarh, thdi1, thdi2, thdi3, thdv1, thdv2, thdv3, tva, vln1, vln2, vln3, vln4) VALUES('" + deviceData.DeviceID + "', '" + Convert.ToDateTime(deviceData.UpdateTime).ToString("yyyy-MM-dd HH:mm:ss") + "', " + Convert.ToInt32(value: deviceData.Alarm) + ", " + Convert.ToInt32(value: deviceData.Alarm10) + ", " + Convert.ToInt32(value: deviceData.Alarm11) + ", " + Convert.ToInt32(value: deviceData.Alarm2) + ", " + Convert.ToInt32(value: deviceData.Alarm3) + ", " + Convert.ToInt32(value: deviceData.Alarm4) + ", " + Convert.ToInt32(value: deviceData.Alarm5) + ", " + Convert.ToInt32(value: deviceData.Alarm6) + ", " + Convert.ToInt32(value: deviceData.Alarm7) + ", " + Convert.ToInt32(value: deviceData.Alarm8) + ", " + Convert.ToInt32(value: deviceData.Alarm9) + ", " + capvarh + ", " + exwh + ", " + Convert.ToInt32(value: deviceData.Generator) + ", " + imwh + ", " + indvarh + ", " + thdi1 + ", " + thdi2 + ", " + thdi3 + ", " + thdv1 + ", " + thdv2 + ", " + thdv3 + ", " + tva + ", " + vln1 + ", " + vln2 + ", " + vln3+ ", " + vln4 + ")\nGO";
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

/*
CreateDeviceDataInserts.cs dosyasından farklı olarak double değişkenlerin ',' alan kısımları '.' ile değiştirildi. 
İşin aciliyeti sebebiyle şimdilik böyle bir çözüm tercih edildi.
*/
