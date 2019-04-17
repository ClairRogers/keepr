<template>
  <div id="app">
    <nav class="navbar navbar-expand-lg bg-blue mb-3">
      <h2 class="pointer logo mr-4" @click="goHome">Keepr</h2>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavAltMarkup"
        aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
        <ul class="navbar-nav mr-auto">
          <li class="nav-item">
            <a class=" nav-link pointer" @click="goHome">Home</a>
          </li>
          <li class="nav-item">
            <a v-if="user.username" class=" nav-link pointer" @click="goDashboard">My Dashboard</a>
          </li>
          <li class="nav-item">
            <a v-if="user.username" class=" nav-link pointer" @click="logout">Logout</a>
          </li>
        </ul>
        <span class="navbar-text">
          <span v-if="user.username">Hello, {{user.username}}</span>
          <span v-else>
            <button class="btn btn-sm btn-outline-secondary mx-2" type="button" data-toggle="modal"
              data-target="#loginModal">Login / Register</button>
          </span>
        </span>
      </div>
    </nav>
    <loginmodal></loginmodal>
    <router-view />
  </div>
</template>

<script>
  import loginmodal from '@/components/loginmodal.vue'
  import router from './router'
  export default {
    name: "app",
    mounted() {
    },
    data() {
      return {}
    },
    computed: {
      user() {
        return this.$store.state.user
      }
    },
    methods: {
      goHome() {
        router.push({ name: 'home' })
      },
      goDashboard() {
        router.push({ name: 'dashboard' })
      },
      logout() {
        this.$store.dispatch('logout')
      }
    },
    components: {
      loginmodal
    }
  };
</script>

<style>
  #app {
    font-family: 'Varela Round', sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: rgb(149, 189, 212);
  }

  body {
    background-color: #222831;
    background-image: url("https://www.transparenttextures.com/patterns/always-grey.png");
    color: rgb(149, 189, 212);
  }

  a {
    color: #00fff5;
    transition: ease all .5s
  }

  a:hover {
    color: #00adb5;
  }

  .navbar-light {
    color: #00fff5;
  }

  .navbar-nav {
    color: #00fff5;
  }

  .nav-item {
    color: #00fff5;
  }

  .nav-link {
    color: #00fff5;
  }

  .logo {
    font-family: 'Righteous', cursive;
    color: #00adb5;
  }

  #nav {
    padding: 30px;
  }

  #nav a {
    font-weight: bold;
    color: #2c3e50;
  }

  #nav a.router-link-exact-active {
    color: #42b983;
  }

  .bg-blue {
    background-color: #393e46;
  }

  .pointer {
    cursor: pointer;
  }

  .btn-secondary {
    background-color: #00fff5;
    color: #393e46;
  }

  .btn-secondary:hover {
    background-color: #00adb5;
  }

  .btn-outline-secondary {
    color: #00fff5;
    border-color: #00fff5;
  }

  .btn-outline-secondary:hover {
    background-color: #00adb5;
    border-color: #00fff5;
  }
</style>