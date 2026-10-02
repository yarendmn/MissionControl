using MissionControl.InterFaces;
using MissionControl.Models;
using System;

namespace MissionControl
{
    class Program
    {
        static MissionUnit[] units = new MissionUnit[20];
        static Mission[] missions = new Mission[50];

        static int unitCount = 0;
        static int missionCount = 0;

        static void Main()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n========= MISSION CONTROL =========");
                Console.WriteLine("\n1 - Unit oluştur\n2 - Unit listele");
                Console.WriteLine("\n3 - Mission oluştur\n4 - Mission listele");
                Console.WriteLine("\n5 - Unit'i göreve ata\n6 - Mission başlat\n7 - Mission tamamla");
                Console.WriteLine("\n8 - Sensör oku\n9 - Mesaj gönder");
                Console.WriteLine("\n10 - Batarya doldur\n11 - Operasyon durumunu göster");
                Console.WriteLine("\n0 - Çıkış\n");
                Console.Write("Seçiminiz: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Tür (1: UAV, 2: GroundVehicle, 3: ObservationStation): ");
                        string type = Console.ReadLine();
                        int newId = unitCount + 1;
                        if (type == "1") units[unitCount++] = new UAV(newId, $"UAV-{newId}");
                        else if (type == "2") units[unitCount++] = new GroundVehicle(newId, $"GROUND-{newId}");
                        else if (type == "3") units[unitCount++] = new ObservationStation(newId, $"STATION-{newId}");
                        break;
                    case "2":
                        for (int i = 0; i < unitCount; i++)
                            Console.WriteLine($"ID: {units[i].Id} | Name: {units[i].Name}");
                        break;
                    case "3":
                        Console.Write("Görev Adı: ");
                        string mName = Console.ReadLine();
                        Console.Write("Gerekli Batarya: ");
                        double reqBat = Convert.ToDouble(Console.ReadLine());
                        missions[missionCount++] = new Mission(missionCount + 100, mName, "Bilinmiyor", reqBat);
                        break;
                    case "4":
                        for (int i = 0; i < missionCount; i++)
                            Console.WriteLine($"ID: {missions[i].MissionId} | Name: {missions[i].MissionName} | ReqBat: {missions[i].RequiredBattery}");
                        break;
                    case "5":
                    case "6":
                        Console.Write("Atanacak Mission ID: ");
                        int mId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Göreve gidecek Unit ID: ");
                        int uId = Convert.ToInt32(Console.ReadLine());

                        Mission selectedMission = null;
                        for (int i = 0; i < missionCount; i++)
                            if (missions[i].MissionId == mId) selectedMission = missions[i];

                        for (int i = 0; i < unitCount; i++)
                        {
                            if (units[i].Id == uId)
                            {
                                if (units[i] is IMissionCapable capableUnit && selectedMission != null)
                                    capableUnit.StartMission(selectedMission);
                            }
                        }
                        break;
                    case "7":
                        Console.Write("Tamamlayacak Unit ID: ");
                        int compId = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < unitCount; i++)
                        {
                            if (units[i].Id == compId && units[i] is IMissionCapable compUnit)
                                compUnit.CompleteMission();
                        }
                        break;
                    case "8":
                        Console.Write("Sensör okuyacak Unit ID: ");
                        int sensId = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < unitCount; i++)
                        {
                            if (units[i].Id == sensId && units[i] is ISensorProvider sensorUnit)
                                sensorUnit.ReadSensor();
                        }
                        break;
                    case "9":
                        Console.Write("Mesaj gönderecek Unit ID: ");
                        int msgId = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < unitCount; i++)
                        {
                            if (units[i].Id == msgId && units[i] is ICommunicable commUnit)
                                commUnit.SendMessage();
                        }
                        break;
                    case "10":
                        Console.Write("Şarj edilecek Unit ID: ");
                        int chargeId = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < unitCount; i++)
                        {
                            if (units[i].Id == chargeId && units[i] is IRechargeable rechargeableUnit)
                                rechargeableUnit.Recharge();
                        }
                        break;
                    case "11":
                        for (int i = 0; i < unitCount; i++)
                        {
                            units[i].GetOperationalStatus();
                            Console.WriteLine();
                        }
                        break;
                    case "0":
                        isRunning = false;
                        break;
                }
            }
        }
    }
}