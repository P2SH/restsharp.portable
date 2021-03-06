﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace RestSharp.Portable
{
    /// <summary>
    /// The default REST request
    /// </summary>
    public class RestRequest : IRestRequest
    {
        private readonly List<Parameter> _parameters = new List<Parameter>();

        /// <summary>
        /// Constructor that initializes with the HTTP GET request method and the JSON serializer as default serializer
        /// </summary>
        public RestRequest()
            : this((string)null, HttpMethod.Get)
        {

        }

        /// <summary>
        /// Constructor that initializes with the HTTP request method and the JSON serializer as default serializer
        /// </summary>
        /// <param name="method">The HTTP request method to use</param>
        public RestRequest(HttpMethod method)
            : this((string)null, method)
        {

        }

        /// <summary>
        /// Constructor that initializes the resource path, HTTP GET request method and the JSON serializer as default serializer
        /// </summary>
        /// <param name="resource"></param>
        public RestRequest(string resource)
            : this(resource, HttpMethod.Get)
        {
        }

        /// <summary>
        /// Constructor that initializes the resource path, HTTP request method and the JSON serializer as default serializer
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="method"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1057:StringUriOverloadsCallSystemUriOverloads", Justification = "resource might be null")]
        public RestRequest(string resource, HttpMethod method)
        {
            ContentCollectionMode = ContentCollectionMode.MultiPartForFileParameters;
            Method = method;
            Resource = resource;
            Serializer = new Serializers.JsonSerializer();
        }

        /// <summary>
        /// Constructor that initializes the resource path, HTTP GET request method and the JSON serializer as default serializer
        /// </summary>
        /// <param name="resource"></param>
        public RestRequest(Uri resource)
            : this(resource, HttpMethod.Get)
        {
        }

        /// <summary>
        /// Constructor that initializes the resource path, HTTP request method and the JSON serializer as default serializer
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="method"></param>
        public RestRequest(Uri resource, HttpMethod method)
            : this((resource.IsAbsoluteUri ? resource.AbsolutePath + resource.Query : resource.OriginalString), method)
        {
        }

        /// <summary>
        /// HTTP request method (GET, POST, etc...)
        /// </summary>
        public HttpMethod Method { get; set; }

        /// <summary>
        /// The resource relative to the REST clients base URL
        /// </summary>
        public string Resource { get; set; }

        /// <summary>
        /// REST request parameters
        /// </summary>
        public IList<Parameter> Parameters { get { return _parameters; } }

        /// <summary>
        /// The serializer that should serialize the body
        /// </summary>
        public Serializers.ISerializer Serializer { get; set; }

        /// <summary>
        /// The credentials used for the request (e.g. NTLM authentication)
        /// </summary>
        public ICredentials Credentials { get; set; }

        /// <summary>
        /// Controls if we use basic content or multi part content by default.
        /// </summary>
        public ContentCollectionMode ContentCollectionMode { get; set; }

        /// <summary>
        /// The <see cref="StringComparer"/> to be used for this request.
        /// </summary>
        /// <remarks>
        /// If this property is null, the <see cref="IRestClient.DefaultParameterNameComparer"/> is used.
        /// </remarks>
        public StringComparer ParameterNameComparer { get; set; }
    }
}
