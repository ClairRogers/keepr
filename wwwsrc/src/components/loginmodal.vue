<template>
  <div class="loginmodal">
    <div class="modal fade" id="loginModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle"
      aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
          <!-- <div class="modal-header">
            <h5 class="modal-title" id="exampleModalCenterTitle">Modal title</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div> -->
          <div class="modal-body">
            <ul class="nav nav-tabs" id="myTab" role="tablist">
              <li class="nav-item">
                <a class="nav-link active" id="login-tab" data-toggle="tab" href="#login" role="tab"
                  aria-controls="login" aria-selected="true">Login</a>
              </li>
              <li class="nav-item">
                <a class="nav-link" id="register-tab" data-toggle="tab" href="#register" role="tab"
                  aria-controls="register" aria-selected="false">Register</a>
              </li>
            </ul>
            <div class="tab-content" id="myTabContent">
              <div class="tab-pane fade show active" id="login" role="tabpanel" aria-labelledby="login-tab">
                <h3 class="mt-3">User Login</h3>
                <form @submit.prevent="loginUser">
                  <input class="form-control mt-3" type="email" v-model="creds.email" placeholder="email">
                  <input class="form-control mt-3" type="password" v-model="creds.password" placeholder="password">
                  <button class="btn btn-secondary mt-3" type="submit">Login</button>
                </form>
              </div>
              <div class="tab-pane fade" id="register" role="tabpanel" aria-labelledby="register-tab">
                <h3 class="mt-3">Register New User</h3>
                <form @submit.prevent="register">
                  <input class="form-control mt-3" type="text" v-model="newUser.username" placeholder="name">
                  <input class="form-control mt-3" type="email" v-model="newUser.email" placeholder="email">
                  <input class="form-control mt-3" type="password" v-model="newUser.password" placeholder="password">
                  <button class="btn btn-secondary mt-3" type="submit">Create Account</button>
                </form>
              </div>
            </div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-outline-secondary" data-dismiss="modal">Close</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: "loginmodal",
    props: [],
    data() {
      return {
        loginForm: true,
        creds: {
          email: "",
          password: ""
        },
        newUser: {
          email: "",
          password: "",
          username: ""
        }
      };
    },
    methods: {
      register() {
        this.$store.dispatch("register", this.newUser);
        $('#loginModal').modal('hide');
      },
      loginUser() {
        this.$store.dispatch("login", this.creds);
        $('#loginModal').modal('hide');
      }
    },
    computed: {},
    components: {}
  }
</script>