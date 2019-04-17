<template>
  <div class="home container">
    <div class="row">
      <div class="col-12 mb-3 logo">
        <h3 v-if="user.username">Welcome, {{user.username}}!</h3>
        <h3 v-else>Welcome to Keepr!</h3>
      </div>
      <div class="card-columns">
        <div v-for="keep in keeps" v-if="keep.isPrivate == false" class="card pointer" @click="setActiveKeep(keep)"
          data-toggle="modal" data-target=".bd-example-modal-lg" @mouseover="showStuff = true"
          @mouseleave="showStuff = false">
          <img :src="keep.img" class="card-img-top">
          <div class="card-body">
            <p class="card-text">{{keep.name}}</p>
          </div>
          <!-- <div class="card-img-overlay p-0 text-left">
            <h2 v-if="showStuff" class="card-text whitecolor pointer"><i class="fas fa-plus-square ml-2 mt-1"></i></h2>
          </div> -->
        </div>
      </div>
    </div>

    <keepviewmodal></keepviewmodal>
  </div>
  </div>
</template>

<script>
  import keepviewmodal from '@/components/keepviewmodal.vue'
  export default {
    name: "home",
    mounted() {
      //blocks users not logged in
      // if (!this.$store.state.user.id) {
      //   this.$router.push({ name: "login" });
      // }
      this.$store.dispatch('getKeeps')
      this.$store.dispatch('getVaults')
    },
    data() {
      return {
        showStuff: false
      }
    },
    computed: {
      keeps() {
        return this.$store.state.keeps
      },
      user() {
        return this.$store.state.user
      }
    },
    methods: {
      setActiveKeep(keep) {
        this.$store.dispatch('setActiveKeep', keep)
        keep.views++
        this.$store.dispatch('editKeep', keep)
      }
    },
    components: {
      keepviewmodal
    }
  };
</script>

<style>
  @media (min-width: 300px) {
    .card-columns {
      column-count: 2;
    }
  }

  @media (min-width: 768px) {
    .card-columns {
      column-count: 2;
    }
  }

  @media (min-width: 992px) {
    .card-columns {
      column-count: 4;
    }
  }

  @media (min-width: 1200px) {
    .card-columns {
      column-count: 4;
    }
  }


  .card {
    background-color: #555d69;
    display: inline-block;
    width: 100%;
    border: 1px solid #00adb5;
  }

  .whitecolor {
    color: white;
    text-shadow: 0 0 1px black;
  }
</style>