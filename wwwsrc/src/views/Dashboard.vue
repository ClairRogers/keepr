<template>
  <div class="dashboard">
    <h1 class="logo mb-3">Your Dashboard</h1>
    <button class="btn btn-outline-secondary btn-sm mx-2 mb-2" data-toggle="modal" data-target="#nkeepmodal">New
      Keep</button>
    <button class="btn btn-outline-secondary btn-sm mx-2 mb-2" data-toggle="modal" data-target="#nvaultmodal">New
      Vault</button>
    <hr>
    <h2 class="text-center d-flex justify-content-center mt-4 mb-5"><span class="pointer mx-3"
        :class="switchViews ? 'selected' : ''" @click="switchViews = true">My Keeps</span> <span class="pointer mx-3"
        :class="!switchViews ? 'selected' : ''" @click="switchViews = false">My
        Vaults</span></h2>
    <div>
      <transition :name="switchViews ? 'first-slide' : 'second-slide'" mode="out-in">
        <mykeeps v-if="switchViews"></mykeeps>
        <myvaults v-if="!switchViews"></myvaults>
      </transition>
    </div>
    <newkeepmodal></newkeepmodal>
    <newvaultmodal></newvaultmodal>
  </div>
</template>

<script>
  import newkeepmodal from '@/components/newkeepmodal.vue'
  import newvaultmodal from '@/components/newvaultmodal.vue'
  import mykeeps from '@/components/mykeeps.vue'
  import myvaults from '@/components/myvaults.vue'

  export default {
    name: "dashboard",
    mounted() {
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
      //let uid = ''
      //this.$store.dispatch('getMyKeeps', this.user.id)
    },
    props: [],
    data() {
      return {
        switchViews: true
      }
    },
    computed: {
      user() {
        return this.$store.state.user
      }
    },
    methods: {},
    components: {
      newkeepmodal,
      newvaultmodal,
      mykeeps,
      myvaults
    }
  }
</script>

<style>
  .selected {
    border-bottom: solid 5px #00fff5;
  }




  .first-slide-enter {
    opacity: 0;
    transform: translatex(-50px);
    transition: all .5s ease-out;
  }

  .first-slide-enter-to {
    opacity: 1;
    transform: translatex(0);
    transition: all .5s ease-out;
  }

  .first-slide-leave-to {
    opacity: 0;
    transform: translatex(50px);
    transition: all .5s ease-out;
  }


  .second-slide-enter {
    opacity: 0;
    transform: translatex(50px);
    transition: all .5s ease-out;
  }

  .second-slide-enter-to {
    opacity: 1;
    transform: translatex(0);
    transition: all .5s ease-out;
  }

  .second-slide-leave-to {
    opacity: 0;
    transform: translatex(-50px);
    transition: all .5s ease-out;
  }
</style>