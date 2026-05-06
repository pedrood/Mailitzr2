using System.Collections.Immutable;
using Newtonsoft.Json;

namespace Mailitzr.Services;

/// <summary>
/// Unsubscribe / suppression list (single responsibility: who must not receive mail).
/// </summary>
public sealed class SuppressedAddressRegistry
{
    private ImmutableHashSet<string> _addresses;

    public SuppressedAddressRegistry()
    {
        _addresses = BuildDefaultSet();
    }

    public void MergeFromJsonFile(string path)
    {
        if (!File.Exists(path))
            return;
        try
        {
            var json = File.ReadAllText(path);
            var extra = JsonConvert.DeserializeObject<List<string>>(json);
            if (extra == null || extra.Count == 0)
                return;
            _addresses = _addresses.Union(extra);
        }
        catch
        {
            // invalid file — keep existing set
        }
    }

    public bool IsSuppressed(string? address)
    {
        return string.IsNullOrEmpty(address) || _addresses.Contains(address);
    }

    private static ImmutableHashSet<string> BuildDefaultSet()
    {
        return ImmutableHashSet.Create(StringComparer.OrdinalIgnoreCase,
            "yarmohammadi.energykia@gmail.com",
            "sarah_taheri6562@yahoo.com",
            "sales1@aryamasir.com",
            "newsletter@dihk.co.ir",
            "mohammaddarvish@glaziers.es",
            "kueh.darrel@inabata.com",
            "hghomshahi@gmail.com",
            "h_sarpoulaki@dihk.co.ir",
            "gh_746@hotmail.com",
            "event@dihk.co.ir",
            "a.mehraban@imexmart.com",
            "a.johari@tgcans.com",
            "sara.roknian@ptbnet.com",
            "maryam.jam@ptbnet.com",
            "fallah@yektalogistics.com",
            "msh@trankaco.com",
            "info@the-business-school.ir",
            "soori@tanialojistik.com",
            "support@streamlife.asia",
            "info@shahamtarabarco.com",
            "m.sayad@samacargo.com",
            "line@mir-shipping.net");
    }
}
