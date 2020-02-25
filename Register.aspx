<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div class="container">

     <div class="card o-hidden border-0 shadow-lg my-5">
      <div class="card-body p-0">
            <div class="p-5">
              <div class="text-center">
                <h1 class="h4 text-gray-900 mb-4">Create an Account!</h1>
              </div>
              <div class="user">
                <div class="form-group row">
                  <div class="col-sm-6 mb-3 mb-sm-0">
                      <!-- change the textbox id: txtFirstName   --> 
                    <asp:TextBox ID="txtFirstName" runat="server" placeholder="First Name" class="form-control form-control-user"></asp:TextBox>  
                  </div>
                  <div class="col-sm-6">
                      <!-- change the textbox id: txtLastName   --> 
                    <asp:TextBox ID="txtLastName" runat="server" placeholder="Last Name" class="form-control form-control-user"></asp:TextBox>
                  </div>
                </div>
                <div class="form-group">
                    <!-- change the textbox id: txtEmail. Change the  TextMode="Email"  --> 
                  <asp:TextBox ID="txtEmail" runat="server"  placeholder="Email Address" class="form-control form-control-user" TextMode="Email"></asp:TextBox>
                </div>
                <div class="form-group row">
                  <div class="col-sm-6 mb-3 mb-sm-0">
                      <!-- change the textbox id: txtPassword.  Change the  TextMode="Password"  -->
                      <asp:TextBox ID="txtPassword" runat="server"  placeholder="Password"  class="form-control form-control-user" TextMode="Password"></asp:TextBox>
                  </div>
                  <div class="col-sm-6">
                      <!-- change the textbox id: txtConfirmPassword. Change the  TextMode="Password"   --> 
                      <asp:TextBox ID="txtConfirmPassword" runat="server"  placeholder="Repeat Password" class="form-control form-control-user" TextMode="Password"></asp:TextBox>
                  </div>
                </div>
                  <div class="form-group">
                      <!-- change the textbox id: txtPhoneNumber. Change the  TextMode="Number"   --> 
                  <asp:TextBox ID="txtPhoneNumber" runat="server"  placeholder="Phone Number" class="form-control form-control-user" TextMode="Number"></asp:TextBox>
                </div>
                  <!-- change the button id: btnRegister. Change   Text="Register Account" --> 
                <asp:Button ID="btnRegister" runat="server" Text="Register Account" class="btn btn-primary btn-user btn-block" OnClick="btnRegister_Click" />
              </div>
              <hr>
              <div class="text-center">
                <a class="small" href="ForgotPassword.aspx">Forgot Password?</a>
              </div>
              <div class="text-center">
                <a class="small" href="Login.aspx">Already have an account? Login!</a>
              </div>
            </div>
          </div>
        </div>
      </div>
</asp:Content>

