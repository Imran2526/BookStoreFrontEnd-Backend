﻿using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSMQ
{
    public class Recever
    {
        /// <summary>
        /// Receive Mail
        /// </summary>
        /// <returns></returns>
        public string MailReciver()
        {
            var reciever = new MessageQueue(@".\Private$\MyQueue");
            var recieving = reciever.Receive();
            recieving.Formatter = new BinaryMessageFormatter();
            string linkToSend = recieving.Body.ToString();
            return linkToSend;
        }
    }
}
