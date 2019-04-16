<template>
  <div id="app">
    <nav class="navbar navbar-expand-lg navbar-light bg-blue mb-3">
      <a class="navbar-brand pointer" @click="goHome">Keepr</a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavAltMarkup"
        aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
        <ul class="navbar-nav mr-auto">
          <li class="nav-item">
            <a class="nav-item nav-link pointer" @click="goHome">Home</a>
          </li>
          <li class="nav-item">
            <a v-if="user.username" class="nav-item nav-link pointer" @click="goDashboard">My Dashboard</a>
          </li>
          <li class="nav-item">
            <a v-if="user.username" class="nav-item nav-link pointer" @click="logout">Logout</a>
          </li>
        </ul>
        <span class="navbar-text">
          <span v-if="user.username">Hello, {{user.username}}</span>
          <span v-else>
            <button class="btn btn-sm btn-outline-success mx-2" type="button">Login / Register</button>
          </span>
        </span>
      </div>
    </nav>
    <router-view />
  </div>
</template>

<script>
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
    }
  };
</script>

<style>
  #app {
    font-family: 'Varela Round', sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #636a75;
  }

  body {
    background-color: #dfdfdf;
    color: rgb(59, 59, 59);
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
    background-color: #bfd8d5;
  }

  .pointer {
    cursor: pointer;
  }
</style>