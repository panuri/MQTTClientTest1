using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// including the M2Mqtt Library
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MQTTClientTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("start");
            // Create Client instance
            MqttClient myClient = new MqttClient("192.168.28.128");

            // Register to message received
            myClient.MqttMsgPublishReceived += client_recievedMessage;

            string clientId = Guid.NewGuid().ToString();
            myClient.Connect(clientId);

            // Subscribe to topic
            myClient.Subscribe(new String[] { "meas/#" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            // myClient.Subscribe(new String[] { "paine" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            // myClient.Subscribe(new String[] { "lämpö" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            System.Console.ReadLine();
        }

       

        static void client_recievedMessage(object sender, MqttMsgPublishEventArgs e)
        {
            // Handle message received
            
            var message = System.Text.Encoding.Default.GetString(e.Message);
            
            System.Console.WriteLine("Message received: " + message + " " + e.Topic);
        }
    }
}
