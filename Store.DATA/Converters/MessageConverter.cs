using Store.DATA.Dto;
using Store.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store.DATA.Converters
{
    public static class MessageConverter
    {
        public static MessageDto Convert(Message message) =>
            new MessageDto
            {
                Name = message.Name,
                Text = message.Text,
                Id = message.Id,
                ItemId = message.ItemId
            };

        public static Message Convert(MessageDto message) =>
            new Message
            {
                Name = message.Name,
                Text = message.Text,
                Id = message.Id,
                ItemId = message.ItemId
            };

        public static List<MessageDto> Convert(List<Message> messages) =>
            messages.Select(a => Convert(a)).ToList();

        public static List<Message> Convert(List<MessageDto> messages) =>
            messages.Select(a => Convert(a)).ToList();
    }
}
