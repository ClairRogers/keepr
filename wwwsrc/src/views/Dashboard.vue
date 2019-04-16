<template>
  <div class="dashboard">
    <h1>Your Dashboard</h1>
    <button class="btn btn-success mx-2" data-toggle="modal" data-target="#nkeepmodal">New Keep</button> <button
      class="btn btn-success mx-2" data-toggle="modal" data-target="#nvaultmodal">New
      Vault</button>
    <h4 v-if="!showCurrent" class="text-center d-flex justify-content-around"><span class="pointer"
        :class="switchViews ? 'selected' : ''" @click="switchViews = true">My Keeps</span> <span class="pointer"
        :class="!switchViews ? 'selected' : ''" @click="switchViews = false">My
        Vaults</span></h4>
    <div v-if="!showCurrent">
      <transition :name="switchViews ? 'first-slide' : 'second-slide'" mode="out-in">
        <mykeeps v-if="switchViews" :user="user"></mykeeps>
        <myvaults v-if="!switchViews" :user="user"></myvaults>
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
      let uid = ''
      this.$store.dispatch('getMyKeeps', uid)
    },
    props: [],
    data() {
      return {
        switchViews: true
      }
    },
    computed: {
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
    border-bottom: solid 5px #13abc4;
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