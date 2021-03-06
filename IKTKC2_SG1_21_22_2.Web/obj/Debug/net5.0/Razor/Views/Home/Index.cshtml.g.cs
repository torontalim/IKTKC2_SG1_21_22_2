#pragma checksum "C:\Users\Eszti\Documents\GitHub\IKTKC2_SG1_21_22_2\IKTKC2_SG1_21_22_2.Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "925f9ed34b073c55fa621abb5eb7085869bd44de"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(IKTKC2_SG1_21_22_2.Web.Pages.Home.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace IKTKC2_SG1_21_22_2.Web.Pages.Home
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Eszti\Documents\GitHub\IKTKC2_SG1_21_22_2\IKTKC2_SG1_21_22_2.Web\Views\_ViewImports.cshtml"
using IKTKC2_SG1_21_22_2.Web;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"925f9ed34b073c55fa621abb5eb7085869bd44de", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05bb1153e9eb84c3376d1e4b2097d44db297b239", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Eszti\Documents\GitHub\IKTKC2_SG1_21_22_2\IKTKC2_SG1_21_22_2.Web\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Player website";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div id=""app"">
    <template v-if=""selectedPage == 'list'"">
        <h1>This is the list page.</h1>

        <button v-on:click=""getPlayers()"">Click here to refresh the player list!</button>
        <button v-on:click=""showEditor(null)"">Add new player!</button>
        <div class=""table flex-center"">
            <div class=""tr flex-center"">
                <div class=""td tr-header flex-center"">Name</div>
                <div class=""td tr-header flex-center"">Email</div>
                <div class=""td tr-header flex-center"">Phone number</div>
                <div class=""td tr-header flex-center"">Date of birth</div>
                <div class=""td tr-header flex-center"">Still active</div>
                <div class=""td flex-center td-empty""></div>
                <div class=""td flex-center td-empty""></div>
                <div class=""td flex-center td-empty""></div>
            </div>
            <div v-for=""player in players"" class=""tr flex-center"">
                <div class=""td flex-center"">");
            WriteLiteral(@"{{ player.name }}</div>
                <div class=""td flex-center"">{{ player.email }}</div>
                <div class=""td flex-center"">{{ player.phoneNumber }}</div>
                <div class=""td flex-center"">{{ player.dateOfBirth }}</div>
                <div class=""td flex-center"">{{ player.active ? 'Yes' : 'No' }}</div>
                <div class=""td flex-center td-button""><button v-on:click=""showEditor(player)"">Edit</button></div>
                <div class=""td flex-center td-button""><button v-on:click=""showDetails(player)"">Details</button></div>
                <div class=""td flex-center td-button""><button v-on:click=""deletePlayer(player)"">Delete</button></div>
            </div>
        </div>
    </template>
    <template v-else-if=""selectedPage == 'details'"">
        <details-component v-bind:player=""selectedPlayer"" v-bind:playerId=""playerId"" v-on:close=""showList""></details-component>
    </template>
    <template v-else>
        <editor-component v-bind:player=""selectedPlayer"" v-on:");
            WriteLiteral(@"close=""showList""></editor-component>
    </template>
</div>

<script>
    new Vue({
        template: '',
        el: `#app`,
        data: {
            players: [],
            selectedPlayerId: 0,
            selectedPlayer: {},
            selectedPage: 'list'
        },
        methods: {
            showDetails(player) {
                this.selectedPlayer = player;
                this.selectedPage = 'details';
            },
            showEditor(player) {
                this.selectedPlayer = player;

                if (this.selectedPlayer == null) {
                    this.selectedPlayerId = 0;
                    this.selectedPlayer = {
                        name: '',
                        email: '',
                        phoneNumber: '',
                        dateOfBirth: null,
                        active: false
                    };
                }
                else {
                    this.selectedPlayerId = player.playerId;

             ");
            WriteLiteral(@"       this.selectedPlayer = {
                        name: player.name,
                        email: player.email,
                        phoneNumber: player.phoneNumber,
                        dateOfBirth: player.dateOfBirth.substring(0, 10),
                        active: player.active
                    };
                }

                this.selectedPage = 'editor';
            },
            showList() {
                this.players = [];
                this.selectedPlayer = null;
                this.getPlayers();

                this.selectedPage = 'list';
            },
            deletePlayer(player) {
                axios.delete('https://localhost:44325/Player/' + player.playerId)
                    .then(response => {
                        alert(response.data);
                        this.getPlayers();
                    });
            },
            getPlayers() {
                this.players = [];
                axios.get('https://localhost:44325/P");
            WriteLiteral(@"layer')
                    .then(response => this.players = response.data);
            }
        },
        created: function () {
            this.showList();
        }
    });

    Vue.component('editor-component', {
        props: ['player', 'playerId'],
        template: '#editor-template',
        methods: {
            savePlayer() {
                if (this.player.playerId > 0) {
                    axios.put('https://localhost:44325/Player/' + this.playerId, this.player)
                        .then(response => {
                            alert(response.data);
                            this.backToList();
                        });
                }
                else {
                    axios.post('https://localhost:44325/Player', this.player)
                        .then(response => {
                            alert(response.data);
                            this.backToList();
                        });
                }
            },
            backToL");
            WriteLiteral(@"ist() {
                this.$emit('close');
            }
        }
    });

    Vue.component('details-component', {
        props: ['player'],
        template: '#details-template',
        methods: {
            backToList() {
                this.$emit('close');
            }
        }
    });

</script>

<script type=""text/x-template"" id=""editor-template"">
    <div class=""flex-col"">
        <h1>This is the editor page.</h1>

        <div class=""flex-col"" style=""width: 300"">
            <div class=""flex"">
                <label>Player</label>
                <input type=""text"" v-model=""player.name"" />
            </div>

            <div class=""flex"">
                <label>Email</label>
                <input type=""text"" v-model=""player.email"" />
            </div>

            <div class=""flex"">
                <label>Phone number:</label>
                <input type=""text"" v-model=""player.phoneNumber"" />
            </div>

            <div class=""flex"">
        ");
            WriteLiteral(@"        <label>Date of birth:</label>
                <input type=""date"" v-model=""player.dateOfBirth"" />
            </div>

            <div class=""flex"">
                <label>Active:</label>
                <input type=""checkbox"" v-model=""player.active"" />
            </div>
        </div>

        <div class=""flex"">
            <button v-on:click=""savePlayer()"">Save</button>
            <button v-on:click=""backToList()"">Back to list</button>
        </div>
    </div>
</script>

<script type=""text/x-template"" id=""details-template"">
    <div class=""flex-col"" style=""width: 300"">
        <h1>Details page</h1>

        <p>Player: {{player.name}}</p>
        <p>Email: {{player.email}}</p>
        <p>Phone number: {{player.phoneNumber}}</p>
        <p>Date of birth: {{player.dateOfBirth}}</p>
        <p>Active: {{ player.active == true ? 'Yes' : 'No' }}</p>
        
        <button v-on:click=""backToList()"">Back to list</button>
    </div>
</script>
");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
