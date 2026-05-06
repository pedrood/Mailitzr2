# Mailitzr2

Windows desktop app for sending **HTML Emails** to a list of recipients through **Microsoft Exchange** using the classic **Exchange Web Services (EWS)** API. Compose or load a template, preview it in the app, merge per-recipient placeholders, respect an unsubscribe/suppression list, and send with pause, resume, and stop controls.

## Features

- **Exchange sending** — Connects with your mailbox credentials and Autodiscover; sends HTML messages as the signed-in account with a configurable display name.
- **Recipients** — Add addresses manually, load a plain-text file (one email per line), filter the list, and remove entries (including double-click to remove).
- **HTML editor & preview** — Edit HTML in the message area; live preview uses **Microsoft Edge WebView2** with zoom shortcuts (75% / 100% / 125%). Default content loads from `Template.html` next to the executable if present.
- **Template tokens** — Replaced per recipient when sending:
  - `{mail}` — recipient address  
  - `{subject}` — subject line  
  - `{date}` — local date as `dd.MM.yyyy`
- **Suppression list** — Addresses in `suppressed-addresses.json` (JSON array of strings) are skipped; merged at startup with any built-in defaults in code.
- **Send job control** — Progress bar, ~**30 second** delay between successful sends (server-friendly throttling), **Pause** / **Resume** / **Stop**, and a **Log** tab with copy/save.
- **Keyboard** — `Ctrl+R` refreshes the preview; `Ctrl+Tab` / `Ctrl+Shift+Tab` cycles email tabs.

## Requirements

| Requirement | Notes |
|-------------|--------|
| **OS** | Windows (WinForms + `net8.0-windows`) |
| **.NET SDK** | [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) |
| **WebView2** | [WebView2 Runtime](https://developer.microsoft.com/microsoft-edge/webview2/) for HTML preview |
| **EWS assembly** | `Microsoft.Exchange.WebServices.dll` — see [Building](#building) |

NuGet packages used by the project: `Microsoft.Web.WebView2`, `Newtonsoft.Json`.

## Building

1. Clone the repository.
2. **EWS reference:** The project expects `Microsoft.Exchange.WebServices.dll` at `bin\Microsoft.Exchange.WebServices.dll` relative to the `.csproj` (see `Mailitzr2.csproj`). Obtain a compatible **Microsoft Exchange Web Services Managed API** assembly from Microsoft’s distribution channel for your environment and place it there **before** building, or update the `<Reference>` `HintPath` to point to your copy.
3. From the repository root:

   ```bash
   dotnet build Mailitzr2.slnx
   ```

   If your SDK does not support `.slnx`, build the project directly:

   ```bash
   dotnet build Mailitzr2.csproj
   ```

   Or open `Mailitzr2.slnx` in Visual Studio and build **Mailitzr2**.

4. Optional files are copied to the output when present next to the project:
   - `Template.html` — default HTML loaded on startup  
   - `suppressed-addresses.json` — extra suppressed addresses, e.g. `["unsub@example.com"]`

## Usage (high level)

1. Enter **mailbox** (sign-in address), **password**, and **display name** for the sender.
2. Set **subject** and compose HTML (or rely on `Template.html`).
3. Add recipients or load a list file.
4. Confirm and **Send**; use the log to verify results.

> **Security:** Treat this like any tool that handles mailbox credentials. Use app passwords or conditional access as required by your organization; do not commit secrets or production recipient lists.

## Project layout

| Area | Purpose |
|------|---------|
| `frmMain` | Main Windows Forms UI, preview, send worker thread, logging |
| `Mail/` | `IEmailSender`, `ExchangeEmailSender`, `OutboundEmail`, connection errors |
| `Services/` | `HtmlEmailTemplateMerger`, `SuppressedAddressRegistry` |
| `Template.html` | Sample newsletter HTML using `{subject}`, `{date}`, etc. |

## Exchange / EWS note

The sender targets **Exchange 2016** EWS version with Autodiscover. On-premises Exchange and policies vary; **Microsoft 365** may require EWS to remain enabled and may steer you toward **Microsoft Graph** for new development. This app is intentionally built on EWS as referenced in the project.

## Author

Created by **Behdad Pedrood** — [github.com/pedrood](https://github.com/pedrood)
