using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Data.DTO
{
    public class HarFile
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string FilePath { get; set; }

        public string UserId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string FileContent { get; set; }

        public string FileName { get; set; }

        public IEnumerable<string> SharedWith { get; set; } = new List<string>();
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Creator
    {
        public string name { get; set; }
        public string version { get; set; }
    }

    public class PageTimings
    {
        public double onContentLoad { get; set; }
        public double onLoad { get; set; }
    }

    public class Page
    {
        public DateTime startedDateTime { get; set; }
        public string id { get; set; }
        public string title { get; set; }
        public PageTimings pageTimings { get; set; }
    }

    public class CallFrame
    {
        public string functionName { get; set; }
        public string scriptId { get; set; }
        public string url { get; set; }
        public int lineNumber { get; set; }
        public int columnNumber { get; set; }
    }

    public class Parent4
    {
        public string description { get; set; }
        public List<CallFrame> callFrames { get; set; }
    }

    public class Stack
    {
        public List<CallFrame> callFrames { get; set; }
    }

    public class Initiator
    {
        public string type { get; set; }
        public string url { get; set; }
        public int? lineNumber { get; set; }
    }

    public class Cache
    {
    }

    public class Header
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class QueryString
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class Cooky
    {
        public string name { get; set; }
        public object value { get; set; }
        public string path { get; set; }
        public string domain { get; set; }
        public DateTime expires { get; set; }
        public bool httpOnly { get; set; }
        public bool secure { get; set; }
        public string sameSite { get; set; }
    }

    public class Request
    {
        public string method { get; set; }
        public string url { get; set; }
        public string httpVersion { get; set; }
        public List<Header> headers { get; set; }
        public List<QueryString> queryString { get; set; }
        //public List<Cooky> cookies { get; set; }
        public int headersSize { get; set; }
        public int bodySize { get; set; }
    }

    public class Content
    {
        public int size { get; set; }
        public string mimeType { get; set; }
        public string text { get; set; }
        public string encoding { get; set; }
    }

    public class Response
    {
        public int status { get; set; }
        public string statusText { get; set; }
        public string httpVersion { get; set; }
        public List<Header> headers { get; set; }
        //public List<Cooky> cookies { get; set; }
        public Content content { get; set; }
        public string redirectURL { get; set; }
        public int headersSize { get; set; }
        public int bodySize { get; set; }
        public int _transferSize { get; set; }
        public string _error { get; set; }
    }

    public class Timings
    {
        public double blocked { get; set; }
        public double dns { get; set; }
        public double ssl { get; set; }
        public double connect { get; set; }
        public double send { get; set; }
        public double wait { get; set; }
        public double receive { get; set; }
        public double _blocked_queueing { get; set; }
    }

    public class Entry
    {
        public Initiator _initiator { get; set; }
        public string _priority { get; set; }
        public string _resourceType { get; set; }
        //public Cache cache { get; set; }
        public string connection { get; set; }
        public string pageref { get; set; }
        public Request request { get; set; }
        public Response response { get; set; }
        public string serverIPAddress { get; set; }
        public DateTime startedDateTime { get; set; }
        public double time { get; set; }
        public Timings timings { get; set; }
    }

    public class Log
    {
        public string version { get; set; }
        public Creator creator { get; set; }
        public List<Entry> entries { get; set; }
    }

    public class HarFileSchemaRoot
    {
        public Log log { get; set; }
    }
}
