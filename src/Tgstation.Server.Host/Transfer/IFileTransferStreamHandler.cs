﻿using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

using Tgstation.Server.Api.Models.Response;

#nullable disable

namespace Tgstation.Server.Host.Transfer
{
	/// <summary>
	/// Reads and writes to <see cref="Stream"/>s associated with <see cref="FileTicketResponse"/>s.
	/// </summary>
	public interface IFileTransferStreamHandler
	{
		/// <summary>
		/// Sets the <see cref="Stream"/> for a given <paramref name="ticketResponse"/> associated with a pending upload.
		/// </summary>
		/// <param name="ticketResponse">The <see cref="FileTicketResponse"/>.</param>
		/// <param name="stream">The <see cref="Stream"/> with uploaded data.</param>
		/// <param name="cancellationToken">The <see cref="CancellationToken"/> for the operation.</param>
		/// <returns>A <see cref="ValueTask{TResult}"/> resulting in <see langword="null"/> if the upload completed successfully, <see cref="ErrorMessageResponse"/> otherwise.</returns>
		ValueTask<ErrorMessageResponse> SetUploadStream(FileTicketResponse ticketResponse, Stream stream, CancellationToken cancellationToken);

		/// <summary>
		/// Gets the the <see cref="Stream"/> for a given <paramref name="ticketResponse"/> associated with a pending download.
		/// </summary>
		/// <param name="ticketResponse">The <see cref="FileTicketResponse"/>.</param>
		/// <param name="cancellationToken">The <see cref="CancellationToken"/> for the operation.</param>
		/// <returns>A <see cref="ValueTask{TResult}"/> resulting in a <see cref="Tuple{T1, T2}"/> containing either a <see cref="Stream"/> containing the data to download or an <see cref="ErrorMessageResponse"/> to return.</returns>
		ValueTask<Tuple<Stream, ErrorMessageResponse>> RetrieveDownloadStream(FileTicketResponse ticketResponse, CancellationToken cancellationToken);
	}
}
