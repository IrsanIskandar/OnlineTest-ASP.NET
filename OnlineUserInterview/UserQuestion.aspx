<%@ Page Title="User Questions" Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserQuestion.aspx.cs" Inherits="OnlineUserInterview.UserQuestion" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PageQuestions" runat="server">
    <div class="container">
        <div class="row justify-content-center">
            <div class="card-columns">
                <div class="card bg-primary">
                    <div class="card-body">
                        <asp:Label ID="lblNama" CssClass="text-white" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="card bg-primary ">
                    <div class="card-body">
                        <asp:Label ID="lblNoTlp" CssClass="text-white" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="card bg-primary">
                    <div class="card-body">
                        <asp:Label ID="lblDivisi" CssClass="text-white" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div class="row justify-content-center">
            <div class="card bg-secondary" style="width: 100%;">
                <div class="card-body text-center text-capitalize" id="TimingLeft" runat="server" data-backdrop="static">
                    <div class="form-inline justify-content-center">
                        <asp:Label ID="lblTitle" CssClass="text-white" runat="server" Text="TIME LEFT :  "></asp:Label>
                        &nbsp;
                        <span id="lblTime" class="text-white">TIME IS NOT START </span>
                        <input id="hidUserID" runat="server" type="hidden" />
                    </div>
                </div>
            </div>
        </div>
        <br />
        <div class="row justify-content-center">
            <div class="col col-md-12 col-lg-12">
                <div class="form-group">
                    <button id="btnSimpanTop" class="btn btn-success form-control insertDataTop" runat="server" type="submit" onserverclick="btnSimpanTop_ServerClick">Simpan Jawaban</button>
                </div>
            </div>
        </div>
        <br />
        <div class="row justify-content-center">
            <div class="accordion" id="accordionQuestion">
                <div class="card">
                    <div class="card-header" id="QuestionOne">
                        <h5 class="mb-0 align-content-center">
                            <a class="btn btn-link collapsed" data-toggle="collapse" data-target="#collQuestOne" runat="server" aria-expanded="false" aria-controls="collQuestOne">
                                <b>First Part Question (Test Database) #1</b>
                            </a>
                        </h5>
                    </div>

                    <div id="collQuestOne" class="collapse show" aria-labelledby="QuestionOne" data-parent="#accordionQuestion">
                        <div class="card-body">
                            <h5 class="h5 text-center">Test Database</h5>
                            <ol>
                                <li>Sebuah database memiliki dua table dengan komposisi sebagai berikut
                                    <br />
                                    <table class="table table-hover table-sm">
                                        <thead>
                                            <tr>
                                                <th>Karayawan</th>
                                                <th>&nbsp;</th>
                                                <th>&nbsp;</th>
                                                <th>Tunjangan</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>Nrp</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>Tanggal</td>
                                            </tr>
                                            <tr>
                                                <td>Nama</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>Nrp</td>
                                            </tr>
                                            <tr>
                                                <td>Alamat</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>Transport</td>
                                            </tr>
                                            <tr>
                                                <td>Telepon</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>Makan</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    Dari table di atas, tolong dibuatkan query untuk keperluan sesuai kriteria di bawah :
                                    <ul>
                                        <li>Ambilkan data tanggal, transport dan makan untuk <b>nrp A8930</b></li>
                                        <li>Ambilkan data nama, alamat, transport dan makan untuk <b>nrp C1288</b> pada tanggal <b>15 Desember 2016</b></li>
                                        <li>Hapus data tunjangan untuk <b>nrp B3555</b> pada tanggal <b>2 Juni 2016</b></li>
                                    </ul>
                                    <div class="form-group">
                                        <textarea runat="server" id="Answer1TD" class="form-control question1TD" rows="5" cols="10" required></textarea>
                                    </div>
                                </li>
                                <li>Apa perintah yang digunakan pada linux untuk melihat isi directory ?
                                    <div class="form-group">
                                        <textarea runat="server" id="Answer2TD" class="form-control question2TD" rows="5" cols="10" required></textarea>
                                    </div>
                                </li>
                                <li>Jelaskan pengertian anda mengenai database dan kegunaannya ?
                                    <div class="form-group">
                                        <textarea runat="server" id="Answer3TD" class="form-control question3TD" rows="5" cols="10" required></textarea>
                                    </div>
                                </li>
                                <li>Apa kegunaan tombol freeze view pada SQL Developer ?
                                    <div class="form-group">
                                        <textarea runat="server" id="Answer4TD" class="form-control question4TD" rows="5" cols="10" required></textarea>
                                    </div>
                                    <%--<div class="form-group align-content-end">
                                        <button id="btnLockAnswersTD" runat="server" class="btn btn-danger btnLockAnswersTD" type="button">Kunci Jawaban</button>
                                    </div>--%>
                                </li>
                            </ol>
                        </div>
                    </div>
                </div>

                <div class="card">
                    <div class="card-header" id="QuestionTwo">
                        <h5 class="mb-0">
                            <a runat="server" class="btn btn-link collapsed" data-toggle="collapse" data-target="#collQuestTwo" aria-expanded="false" aria-controls="collQuestTwo">
                                <b>Second Part Question (Test General IT) #2</b>
                            </a>
                        </h5>
                    </div>
                    <div id="collQuestTwo" class="collapse" aria-labelledby="QuestionTwo" data-parent="#accordionQuestion">
                        <div class="card-body">
                            <ol>
                                <li>Anda seorang IT Support. Suatu saat anda dihubungi oleh user cabang yang mengatakan bahwa mereka tidak dapat
                                    <br />
                                    terkoneksi ke aplikasi yang digunakan, apakah yang anda lakukan ?
                                    <div class="form-group">
                                        <textarea id="Answer1TGI" runat="server" class="form-control question1TGI" rows="5" cols="10" required></textarea>
                                    </div>
                                </li>
                                <li>Bagaimana cara mengatasi virus ?
                                    <div class="form-group">
                                        <textarea id="Answer2TGI" runat="server" class="form-control question2TGI" rows="5" cols="10" required></textarea>
                                    </div>
                                </li>
                                <li>Apa nama ekstension untuk database file Microsoft Outlook ?
                                    <div class="form-group">
                                        <textarea id="Answer3TGI" runat="server" class="form-control question3TGI" rows="5" cols="10" required></textarea>
                                    </div>
                                </li>
                                <li>Apa perintah untuk melihat isi didalam suatu directory pada Microsoft dan Linux ?
                                    <div class="form-group">
                                        <textarea id="Answer4TGI" runat="server" class="form-control question4TGI" rows="5" cols="10" required></textarea>
                                    </div>
                                </li>
                                <li>Sebutkan jenis - jenis protocol dalam jaringan yang anda ketahui ?
                                    <div class="form-group">
                                        <textarea id="Answer5TGI" runat="server" class="form-control question5TGI" rows="5" cols="10" required></textarea>
                                    </div>
                                    <%--<div class="form-group  align-content-end">
                                        <button id="btnLockAnswersTGI" runat="server" class="btn btn-danger btnLockAnswersTGI" type="button">Kunci Jawaban</button>
                                    </div>--%>
                                </li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <div class="row justify-content-center">
            <div class="col col-md-12 col-lg-12">
                <p class="text-center h3">Good Luck 😊</p>
            </div>
        </div>
        <div class="row justify-content-center">
            <div class="col col-md-12 col-lg-12">
                <div class="form-group">
                    <button id="btnSimpanBottom" class="btn btn-success form-control insertDataBottom" runat="server" type="submit" onserverclick="btnSimpanBottom_ServerClick">Simpan Jawaban</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal -->
    <div class="modal fade" id="expireSession" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" runat="server">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Warning Time Is Running Out</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    Your deadline is running out. Quickly resolve unanswered questions. Maximize your answers, to get perfect results.<br />

                    the time you live&nbsp;<b><span id="timeLabel" runat="server"></span></b>&nbsp;Seconds.
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <!-- // Modal -->

    <script type="text/javascript">
        function SessionExpireAlert(timeout) {
            var minutes = timeout / 1000;

            var seconds = $('#lblTime').timeTo({
                seconds: minutes
            });

            document.getElementsByName('lblTime').innerHTML = seconds;

            setTimeout(function () {
                //Show Popup before 60 seconds of timeout.
                $('[id*=expireSession]').modal('show');
                document.getElementById('timeLabel').innerHTML = seconds;
            }, timeout - 60 * 1000);
            setTimeout(function () {
                //Show Popup before 30 seconds of timeout.
                $('[id*=expireSession]').modal('show');
                document.getElementById('timeLabel').innerHTML = seconds;
            }, timeout - 30 * 1000);

            setTimeout(function () {
                $('#<%= Answer1TD.ClientID %>').attr('readonly', 'readonly');
                $('#<%= Answer2TD.ClientID %>').attr('readonly', 'readonly');
                $('#<%= Answer3TD.ClientID %>').attr('readonly', 'readonly');
                $('#<%= Answer4TD.ClientID %>').attr('readonly', 'readonly');
                $('#<%= Answer1TGI.ClientID %>').attr('readonly', 'readonly');
                $('#<%= Answer2TGI.ClientID %>').attr('readonly', 'readonly');
                $('#<%= Answer3TGI.ClientID %>').attr('readonly', 'readonly');
                $('#<%= Answer4TGI.ClientID %>').attr('readonly', 'readonly');
                $('#<%= Answer5TGI.ClientID %>').attr('readonly', 'readonly');
                $('#<%= hidUserID.ClientID %>').attr('readonly', 'readonly');
            }, timeout);
        };

        function insertDataAnswer() {
            var addUserAnswer = {};
            addUserAnswer.AnswersOne = $('#<%= Answer1TD.ClientID %>').val();
            addUserAnswer.AnswersTwo = $('#<%= Answer2TD.ClientID %>').val();
            addUserAnswer.AnswersThree = $('#<%= Answer3TD.ClientID %>').val();
            addUserAnswer.AnswersFourth = $('#<%= Answer4TD.ClientID %>').val();
            addUserAnswer.AnswersFive = $('#<%= Answer1TGI.ClientID %>').val();
            addUserAnswer.AnswersSix = $('#<%= Answer2TGI.ClientID %>').val();
            addUserAnswer.AnswersSeven = $('#<%= Answer3TGI.ClientID %>').val();
            addUserAnswer.AnswersEight = $('#<%= Answer4TGI.ClientID %>').val();
            addUserAnswer.AnswersNine = $('#<%= Answer5TGI.ClientID %>').val();
            addUserAnswer.Usr_InterviewID = $('#<%= hidUserID.ClientID %>').val();

            $.ajax({
                url: 'OnlineTestService.asmx/SaveAnswerServiceAsync',
                type: 'POST',
                contentType: 'application/json; charset=UTF-8',
                data: '{addAnswer:' + JSON.stringify(addUserAnswer) + '}',
                dataType: 'json',
                success: function (data) {
                    if (data.d != null) {
                        alert('Successfully Save Data.\nGood Luck.');
                        $(location).attr('href', 'Congratulation');
                    }
                },
                error: function (data) {
                    console.log(data.d);
                }
            });
        };
    </script>
</asp:Content>
