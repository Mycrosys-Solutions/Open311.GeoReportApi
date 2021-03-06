namespace Open311.GeoReportApi.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    [DataContract(Name = Open311Constants.ModelProperties.ServiceRequest, Namespace = Open311Constants.DefaultNamespace)]
    public class ServiceRequest
    {
        public ServiceRequest()
        {
            RequestedDatetime = DateTimeOffset.Now;
        }

        /// <summary>
        /// The unique ID of the service request created.
        /// </summary>
        [DataMember(Name = Open311Constants.ModelProperties.ServiceRequestId)]
        public string ServiceRequestId { get; set; }

        /// <summary>
        /// The current status of the service request.
        /// </summary>
        [DataMember(Name = Open311Constants.ModelProperties.ServiceRequestStatus)]
        public ServiceRequestStatus Status { get; set; }

        /// <summary>
        /// Explanation of why status was changed to current state or more
        /// details on current status than conveyed with status alone.
        /// </summary>
        [DataMember(Name = Open311Constants.ModelProperties.StatusNotes)]
        public string StatusNotes { get; set; }

        /// <summary>
        /// The human readable name of the service request type.
        /// </summary>
        [DataMember(Name = Open311Constants.ModelProperties.ServiceName)]
        public string ServiceName { get; set; }

        /// <summary>
        /// The unique identifier for the service request type.
        /// </summary>
        [DataMember(Name = Open311Constants.ModelProperties.ServiceCode)]
        public string ServiceCode { get; set; }

        /// <summary>
        /// A full description of the request or report submitted.
        /// This may contain line breaks, but not html or code.
        /// Otherwise, this is free form text limited to 4,000 characters.
        /// </summary>
        [MaxLength(4000)]
        [Display(Name = Open311Constants.ModelProperties.Description)]
        [DataMember(Name = Open311Constants.ModelProperties.Description)]
        public string Description { get; set; }

        /// <summary>
        /// The agency responsible for fulfilling or otherwise addressing the service request.
        /// May not be returned.
        /// </summary>
        [DataMember(Name = Open311Constants.ModelProperties.AgencyResponsible)]
        public string AgencyResponsible { get; set; }

        /// <summary>
        /// Information about the action expected to fulfill the request
        /// or otherwise address the information reported.
        /// May not be returned.
        /// </summary>
        [DataMember(Name = Open311Constants.ModelProperties.ServiceNotice)]
        public string ServiceNotice { get; set; }

        /// <summary>
        /// The date and time when the service request was made.
        /// </summary>
        [IgnoreDataMember]
        public DateTimeOffset RequestedDatetime { get; set; }

        [DataMember(Name = Open311Constants.ModelProperties.RequestedDatetime)]
        internal string RequestedDatetimeString
        {
            get { return RequestedDatetime.ToString("o"); }

#if NETSTANDARD
            set
            {
                throw new NotSupportedException(
                    "Enabled only because DataContractSerializer does not honor SerializeReadOnlyTypes in netstandard, see https://github.com/mrich316/Open311.GeoReportApi/issues/1");
            }
#endif
        }

        /// <summary>
        /// The date and time when the service request was last modified.
        /// For requests with status=closed, this will be the date the request was closed.
        /// </summary>
        [IgnoreDataMember]
        public DateTimeOffset? UpdatedDatetime { get; set; }

        [DataMember(Name = Open311Constants.ModelProperties.UpdatedDatetime)]
        internal string UpdatedDatetimeString
        {
            get { return UpdatedDatetime?.ToString("o"); }

#if NETSTANDARD
            set
            {
                throw new NotSupportedException(
                    "Enabled only because DataContractSerializer does not honor SerializeReadOnlyTypes in netstandard, see https://github.com/mrich316/Open311.GeoReportApi/issues/1");
            }
#endif
        }

        /// <summary>
        /// The date and time when the service request can be expected to be fulfilled.
        /// This may be based on a service-specific service level agreement.
        /// May not be returned.
        /// </summary>
        [IgnoreDataMember]
        public DateTimeOffset? ExpectedDatetime { get; set; }

        [DataMember(Name = Open311Constants.ModelProperties.ExpectedDatetime)]
        internal string ExpectedDatetimeString
        {
            get { return ExpectedDatetime?.ToString("o"); }

#if NETSTANDARD
            set
            {
                throw new NotSupportedException(
                    "Enabled only because DataContractSerializer does not honor SerializeReadOnlyTypes in netstandard, see https://github.com/mrich316/Open311.GeoReportApi/issues/1");
            }
#endif
        }

        /// <summary>
        /// Human readable address or description of location.
        /// </summary>
        /// <remarks>
        /// This should be provided from most specific to most general geographic unit,
        /// eg: address number or cross streets, street name, neighborhood/district, city/town/village, county, postal code.
        /// </remarks>
        [DataMember(Name = Open311Constants.ModelProperties.Address)]
        public string Address { get; set; }

        /// <summary>
        /// The internal address ID used by a jurisdiction’s master address repository or other addressing system.
        /// </summary>
        [DataMember(Name = Open311Constants.ModelProperties.AddressId)]
        public string AddressId { get; set; }

        /// <summary>
        /// The postal code for the location of the service request.
        /// </summary>
        [DataMember(Name = Open311Constants.ModelProperties.Zipcode)]
        public string Zipcode { get; set; }

        /// <summary>
        /// Latitude using the (WGS84) projection.
        /// </summary>
        [DataMember(Name = Open311Constants.ModelProperties.Lat)]
        public double? Lat { get; set; }

        /// <summary>
        /// Longitude using the (WGS84) projection.
        /// </summary>
        [DataMember(Name = Open311Constants.ModelProperties.Long)]
        public double? Long { get; set; }

        /// <summary>
        /// A URL to media associated with the request, eg an image.
        /// </summary>
        /// <remarks>
        /// A convention for parsing media from this URL has yet to be established,
        /// so currently it will be done on a case by case basis much like Twitter.com does.
        /// For example, if a jurisdiction accepts photos submitted via Twitpic.com, then clients
        /// can parse the page at the Twitpic URL for the image given the conventions of Twitpic.com.
        /// This could also be a URL to a media RSS feed where the clients can
        /// parse for media in a more structured way.
        /// </remarks>
        [DataMember(Name = Open311Constants.ModelProperties.MediaUrl)]
        public Uri MediaUrl { get; set; }
    }
}
