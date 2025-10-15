using System;

namespace AceKreme_v1.ViewModels
{
    /// <summary>
    /// Standard error view model for displaying request or server errors.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Unique request identifier, useful for logging or troubleshooting.
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Determines whether the request ID should be displayed in the view.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        /// <summary>
        /// Optional user-friendly message for custom error handling.
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Optional timestamp to record when the error occurred.
        /// </summary>
        public DateTime? OccurredAt { get; set; } = DateTime.UtcNow;
    }
}
